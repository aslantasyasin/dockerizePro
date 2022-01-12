using Koton.Catalog.API.Services.Log;
using Koton.Catalog.API.Services.Product.Post;
using Koton.Catalog.Common.Dtos;
using Koton.Catalog.Common.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koton.Catalog.API.Application.Consumers
{
    public class ProductUpdateMessageCommandConsumer : IConsumer<ProductUpdateMessageCommand>
    {
        private readonly IProductPostAction _productPostAction;
        private readonly ILogAction _logAction;

        public ProductUpdateMessageCommandConsumer(IProductPostAction productPostAction, ILogAction logAction)
        {
            _productPostAction = productPostAction;
            _logAction = logAction;
        }

        public async Task Consume(ConsumeContext<ProductUpdateMessageCommand> context)
        {
            try
            {
                ProductUpdateRequestDto productUpdate = new ProductUpdateRequestDto();
                productUpdate.ProductId = context.Message.ProductId;
                productUpdate.Quantity = context.Message.StockQuantity;
                var result = await _productPostAction.ProductUpdate(productUpdate);

                if (!result.Success) _logAction.InsertLog(result.Message, "ProductUpdateMessageCommandConsumer.ProductUpdate");
            }
            catch (Exception ex)
            {
                _logAction.InsertLog(ex, "ProductPostAction.ProductUpdate");
            }

        }
    }
}
