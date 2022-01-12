using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Basket.Common.Dtos
{
    public class BillingDto
    {
        public decimal ItemPrice { get; set; }
        public int[] Discounts { get; set; }
        public int[] Taxes { get; set; }
        public decimal TotalCost { get; set; }
    }
}
