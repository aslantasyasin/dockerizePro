using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Basket.Common.Messages
{
    public class ProductUpdateMessageCommand
    {
        public int ProductId { get; set; }
        public int StockQuantity { get; set; }
    }
}

