using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Basket.Infrastructure.Core.Entities
{
    public class District
    {
        public District()
        {
            Addresses = new List<Address>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CityId { get; set; }
        public virtual IList<Address> Addresses { get; set; }
    }
}
