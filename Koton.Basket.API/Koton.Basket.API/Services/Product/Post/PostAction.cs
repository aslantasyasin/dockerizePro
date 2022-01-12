using Koton.Basket.API.RabbitMQ;
using Koton.Basket.API.Services.Log;
using Koton.Basket.Common.Base;
using Koton.Basket.Common.Dtos;
using Koton.Basket.Common.Messages;
using Koton.Basket.Infrastructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koton.Basket.API.Services.Product.Post
{
    public class PostAction : IPostAction
    {
        private readonly IProductRepository _productRepository;
        private readonly IRabbitMQMessagePublisher _rabbitMQMessagePublisher;
        private readonly ILogAction _logAction;

        public PostAction(IProductRepository productRepository, IRabbitMQMessagePublisher rabbitMQMessagePublisher, ILogAction logAction)
        {
            _productRepository = productRepository;
            _rabbitMQMessagePublisher = rabbitMQMessagePublisher;
            _logAction = logAction;
        }

        public async Task<ApiResponse> StockControl(StockControlRequestDto stockControlRequest)
        {
            try
            {
                var result = await _productRepository.GetAsync(x => x.Id == stockControlRequest.ProductId);

                if (result == null)
                    return new ApiResponse(201, "Product not found!");
                else
                {
                    if (result.StockQuantity >= stockControlRequest.Quantity)
                    {
                        var backupStockQuantity = result.StockQuantity;

                        var messageCommand = new ProductUpdateMessageCommand();
                        messageCommand.ProductId = stockControlRequest.ProductId;
                        messageCommand.StockQuantity = stockControlRequest.Quantity;

                        await _rabbitMQMessagePublisher.Send<ProductUpdateMessageCommand>(messageCommand, "queue:update-product");

                        result.StockQuantity = backupStockQuantity - stockControlRequest.Quantity;
                        var updateResult = await _productRepository.Update(result);

                        if (updateResult) return new ApiResponse(200, "Transaction successful", updateResult);
                        else 
                        {
                            messageCommand.StockQuantity = backupStockQuantity;
                            await _rabbitMQMessagePublisher.Send<ProductUpdateMessageCommand>(messageCommand, "queue:update-product");
                            return new ApiResponse(203, "Update is failed!");
                        }

                    }
                    else
                        return new ApiResponse(202, "Product is out of stock!");
                }
            }
            catch (Exception ex)
            {
                _logAction.InsertLog(ex, "PostAction.StockControl");
                return new ApiResponse(201, exception: ex.Message);
            }
        }
    }
}
