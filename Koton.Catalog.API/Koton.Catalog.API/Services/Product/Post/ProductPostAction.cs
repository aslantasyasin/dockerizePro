using Koton.Catalog.API.Services.Log;
using Koton.Catalog.Common.Base;
using Koton.Catalog.Common.Dtos;
using Koton.Catalog.Infrastructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koton.Catalog.API.Services.Product.Post
{
    public class ProductPostAction : IProductPostAction
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogAction  _logAction;

        public ProductPostAction(IProductRepository productRepository, ILogAction logAction)
        {
            _productRepository = productRepository;
            _logAction = logAction;
        }

        public async Task<ApiResponse> ProductUpdate(ProductUpdateRequestDto productUpdateRequest)
        {
            try
            {
                var result = await _productRepository.GetAsync(x => x.Id == productUpdateRequest.ProductId);

                if (result == null)
                    return new ApiResponse(201, "Product not found!");
                else
                {
                    if (result.StockQuantity >= productUpdateRequest.Quantity)
                    {
                        result.StockQuantity = result.StockQuantity - productUpdateRequest.Quantity;
                        var updateResult = await _productRepository.Update(result);

                        if (updateResult) return new ApiResponse(200, "Transaction successful", updateResult);
                        else return new ApiResponse(203, "Update is failed!");
                    }
                    else
                        return new ApiResponse(202, "Product is out of stock!");
                }
            }
            catch (Exception ex)
            {
                _logAction.InsertLog(ex, "ProductPostAction.ProductUpdate");
                return new ApiResponse(201, exception: ex.Message);
            }
        }
    }
}
