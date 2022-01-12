using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Basket.Infrastructure.Core.Entities
{
    public class City
    {
        public City()
        {
            Addresses = new List<Address>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual IList<Address> Addresses { get; set; }
    }
}
