using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;

namespace YemekSiparis.DAL.Mappings
{
    public class BeverageMap : IEntityTypeConfiguration<Beverage>
    {
        public void Configure(EntityTypeBuilder<Beverage> builder)
        {
            builder.HasData(new Beverage
            {
                Id = 1,
                Name = "Kola",
                Price = 12.00m,
                Stock = 30,
                Status = Status.Active,
                CreatedDate = DateTime.Now,
               
            });
            builder.HasData(new Beverage
            {
                Id = 2,
                Name = "Ayran",
                Price = 8.50m,
                Stock = 45,
                Status = Status.Active,
                CreatedDate = DateTime.Now,

            });
            builder.HasData(new Beverage
            {
                Id = 3,
                Name = "Soda",
                Price = 6.00m,
                Stock = 53,
                Status = Status.Active,
                CreatedDate = DateTime.Now,

            });
            builder.HasData(new Beverage
            {
                Id = 4,
                Name = "Su",
                Price = 4.50m,
                Stock = 46,
                Status = Status.Active,
                CreatedDate = DateTime.Now,

            });
        }
    }
}
