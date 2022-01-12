using Koton.Catalog.Infrastructure.Core.Entities;
using Koton.Catalog.Infrastructure.Core.Repositories;
using Koton.Catalog.Infrastructure.Data;
using Koton.Catalog.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Catalog.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CatalogContext dbContext) : base(dbContext)
        {

        }
    }
}
