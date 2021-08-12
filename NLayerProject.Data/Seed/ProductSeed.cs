using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Seed
{
    class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;

        public ProductSeed(int[] ids)
        {
            _ids = ids;

        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Pilot Kalem", Price = 12.50m, Stock = 100,
                    CategoryId = _ids[0]},
                new Product
                {
                    Id = 2,
                    Name = "Kurşun Kalem",
                    Price = 40.50m,
                    Stock = 50,
                    CategoryId = _ids[0]
                },
                new Product
                {
                    Id = 3,
                    Name = "Tükenmez Kalem",
                    Price = 500m,
                    Stock = 40,
                    CategoryId = _ids[0]
                },
                new Product
                {
                    Id = 4,
                    Name = "Küçük boy Defter",
                    Price = 12.50m,
                    Stock = 100,
                    CategoryId = _ids[1]
                },
                 new Product
                 {
                     Id = 5,
                     Name = "Orta boy Defter",
                     Price = 12.50m,
                     Stock = 100,
                     CategoryId = _ids[1]
                 },
                  new Product
                  {
                      Id = 6,
                      Name = "Büyük boy Defter",
                      Price = 12.50m,
                      Stock = 100,
                      CategoryId = _ids[1]
                  }
                );
        }
    }
}
