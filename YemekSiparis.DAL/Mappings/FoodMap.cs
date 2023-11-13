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
    public class FoodMap : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasData(new Food
            {
                Id = 1,
                Name = "SteakHouse",
                Stock = 20,
                Price = 120m,
                CategoryID = 1,
                Description = "110 gr. Helal Dana Eti, Cheader Peyniri, Karamelize Soğan",
                CreatedDate = DateTime.Now,
                Status = Status.Active,              
                PrepTime = 20,
                   
            });
            builder.HasData(new Food
            {
                Id = 2,
                Name = "Margarita Bol Malzemos",
                Stock = 30,
                Price = 110m,
                CategoryID = 2,
                Description = "Mozeralla,Domates",
                CreatedDate = DateTime.Now,
                Status = Status.Active,
                PrepTime = 24,

            });
            builder.HasData(new Food
            {
                Id = 3,
                Name = "Penne Soslu Makarna",
                Stock = 45,
                Price = 125m,
                CategoryID = 3,
                Description = "Penne Sosu, Krema",
                CreatedDate = DateTime.Now,
                Status = Status.Active,
                PrepTime = 30,

            });
        }
    }
}
