using Koton.Catalog.Common.Base;
using Koton.Catalog.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koton.Catalog.API.Services.Product.Post
{
    public interface IProductPostAction
    {
        Task<ApiResponse> ProductUpdate(ProductUpdateRequestDto productUpdateRequest);
    }
}
