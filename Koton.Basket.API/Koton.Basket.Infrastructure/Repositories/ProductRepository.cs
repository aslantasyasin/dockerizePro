using Koton.Basket.Infrastructure.Core.Entities;
using Koton.Basket.Infrastructure.Core.Repositories;
using Koton.Basket.Infrastructure.Data;
using Koton.Basket.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Basket.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(BasketContext dbContext): base (dbContext)
        {

        }
    }
}
