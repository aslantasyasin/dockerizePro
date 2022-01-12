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
    public class CategorySeedData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                  new Category() { Id = 1, Name = "Category" },
                         new Category() { Id = 2, Name = "Category2" },
                         new Category() { Id = 3, Name = "Category3" }
                );
        }
    }
}
