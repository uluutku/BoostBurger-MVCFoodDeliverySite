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
    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasData(new OrderDetail
            {
                Id = 1,
                FoodID = 1,
                CreatedDate = DateTime.Now,
                OrderBagID = 1,
                UnitPrice = 150.00m,
                Quantity = 1,
                Status = Status.Active,
                FoodSize = FoodSize.Medium
            });

            builder.HasData(new OrderDetail
            {
                Id = 2,
                FoodID = 2,
                CreatedDate = DateTime.Now,
                OrderBagID = 1,
                UnitPrice = 160.00m,
                Quantity = 1,
                Status = Status.Active,               
                FoodSize = FoodSize.Medium

            });


            
        }
    }
}
