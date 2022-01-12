using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Basket.Common.Dtos
{
    public class StockControlRequestDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        //public int Stock { get; set; }
        //public CustomerDto Customer { get; set; }
        //public BillingDto Billing { get; set; }
        //public string Status { get; set; }

    }
}
