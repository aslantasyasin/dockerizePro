using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Catalog.Infrastructure.Core.Entities
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string StockCode { get; set; }
        [Required]
        public string Unit { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        [Required]

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}
