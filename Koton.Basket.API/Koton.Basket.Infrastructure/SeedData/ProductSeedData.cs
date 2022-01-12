using Koton.Basket.Infrastructure.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Basket.Infrastructure.SeedData
{
    public class ProductSeedData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                  new Product() { Id = 1, StockQuantity = 500 },
                         new Product() { Id = 2, StockQuantity = 100 },
                         new Product() { Id = 3, StockQuantity = 25 }
                );
        }
    }
}
