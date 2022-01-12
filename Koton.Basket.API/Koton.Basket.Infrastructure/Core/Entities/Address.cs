using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Basket.Infrastructure.Core.Entities
{
    public class Address
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string AddressesName { get; set; }
        [Required]
        public string AddressesDesc { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int DistrictId { get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
