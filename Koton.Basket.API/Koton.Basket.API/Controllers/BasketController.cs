using Koton.Basket.API.Services.Product.Post;
using Koton.Basket.Common.Base;
using Koton.Basket.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Koton.Basket.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IPostAction _postAction;

        public BasketController(IPostAction postAction)
        {
            _postAction = postAction;
        }

        [HttpPost]
        public async Task<ApiResponse> Control(StockControlRequestDto stockControlRequest)
        {
            try
            {
                return await _postAction.StockControl(stockControlRequest);
            }
            catch (Exception ex)
            {
                return new ApiResponse((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
