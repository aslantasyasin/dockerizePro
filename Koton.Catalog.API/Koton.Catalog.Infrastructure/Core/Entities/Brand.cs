using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Catalog.Infrastructure.Core.Entities
{
    public class Brand
    {
        public Brand()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Product> Products { get; set; }

    }
}
