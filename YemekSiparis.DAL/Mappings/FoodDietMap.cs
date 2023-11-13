using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.DAL.Mappings
{
    public class FoodDietMap : IEntityTypeConfiguration<FoodDiet>
    {
        public void Configure(EntityTypeBuilder<FoodDiet> builder)
        {
            builder.HasKey(x => new { x.DietID, x.FoodID });

            builder.HasData(new FoodDiet
            {
                FoodID = 1,
                 DietID = 1,

            });

            builder.HasData(new FoodDiet
            {
                FoodID = 2,
                DietID = 2,

            });
        }
    }
}
