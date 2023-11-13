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
    public class DietMap : IEntityTypeConfiguration<Diet>
    {
        public void Configure(EntityTypeBuilder<Diet> builder)
        {

            builder.HasData(new Diet
            {
                Id = 1,
                Name = "Glutensiz",
                CreatedDate = DateTime.Now,
                Status = Status.Active,
                 Description= "Sağlıkla Tüketebilirsiniz"
                
            });

            builder.HasData(new Diet
            {
                Id = 2,
                Name = "Vejeteryan",
                CreatedDate = DateTime.Now,
                Status = Status.Active,
                Description = "Hayvanları koruyalım ve sevelim"
            });
        }
    }
}
