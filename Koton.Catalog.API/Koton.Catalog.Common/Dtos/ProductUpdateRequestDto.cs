using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Catalog.Common.Dtos
{
    public class ProductUpdateRequestDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
