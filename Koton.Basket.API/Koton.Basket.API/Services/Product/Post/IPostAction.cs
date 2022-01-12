using Koton.Basket.Common.Base;
using Koton.Basket.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koton.Basket.API.Services.Product.Post
{
    public interface IPostAction
    {
        Task<ApiResponse> StockControl(StockControlRequestDto stockControlRequest);
    }
}
