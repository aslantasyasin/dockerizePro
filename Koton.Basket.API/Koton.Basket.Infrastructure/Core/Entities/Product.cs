using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Basket.Infrastructure.Core.Entities
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int StockQuantity { get; set; }
      
    }
}
