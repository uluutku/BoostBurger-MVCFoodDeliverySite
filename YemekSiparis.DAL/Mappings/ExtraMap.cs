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
    public class ExtraMap : IEntityTypeConfiguration<Extra>
    {
        public void Configure(EntityTypeBuilder<Extra> builder)
        {
            builder.HasData(new Extra
            {
                Id = 1,
                Name = "Buffalo Sos",
                Price = 4.99m,
                CreatedDate = DateTime.Now,
                Status = Status.Active,
                Stock = 164,
            });

            builder.HasData(new Extra
            {
                Id = 2,
                Name = "Ketçap",
                Price = 2.99m,
                CreatedDate = DateTime.Now,
                Status = Status.Active,
                Stock = 545,
            });

            builder.HasData(new Extra
            {
                Id = 3,
                Name = "Mayonez",
                Price = 2.99m,
                CreatedDate = DateTime.Now,
                Status = Status.Active,
                Stock = 454,
            });

        }
    }
}
