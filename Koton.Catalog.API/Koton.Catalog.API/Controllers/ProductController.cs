using Koton.Catalog.API.Services.Product.Post;
using Koton.Catalog.Common.Base;
using Koton.Catalog.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Koton.Catalog.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductPostAction _productPostAction;

        public ProductController(IProductPostAction productPostAction)
        {
            _productPostAction = productPostAction;
        }

        [HttpPost]
        public async Task<ApiResponse> Update(ProductUpdateRequestDto productUpdateRequest)
        {
            try
            {
                return await _productPostAction.ProductUpdate(productUpdateRequest);
            }
            catch (Exception ex)
            {
                return new ApiResponse((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
