using Koton.Catalog.Infrastructure.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.Catalog.Infrastructure.SeedData
{
    public class ProductSeedData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                  new Product() { Id = 1, BrandId=1, CategoryId=1, Name="Product1", Unit = "adet", Price = 50, StockCode="1234ERT", StockQuantity = 500 },
                         new Product() { Id = 2, BrandId = 2, CategoryId = 1, Name = "Product2", Unit = "adet", Price = 125, StockCode = "1234WQT", StockQuantity = 100 },
                         new Product() { Id = 3, BrandId = 1, CategoryId = 3, Name = "Product3", Unit = "adet", Price = 12, StockCode = "122323RT", StockQuantity = 25 }
                );
        }
    }
}
