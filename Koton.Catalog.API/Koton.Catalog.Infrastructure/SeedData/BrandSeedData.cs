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
    class BrandSeedData : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                  new Brand() { Id = 1, Name = "Brand1" },
                         new Brand() { Id = 2, Name = "Brand2" },
                         new Brand() { Id = 3, Name = "Brand3" }
                );
        }
    }
}
