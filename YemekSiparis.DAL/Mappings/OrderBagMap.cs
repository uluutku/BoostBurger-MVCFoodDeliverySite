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
    public class OrderBagMap : IEntityTypeConfiguration<OrderBag>
    {
        public void Configure(EntityTypeBuilder<OrderBag> builder)
        {
            builder.HasData(new OrderBag
            {
                Id = 1,
                CustomerId = 1,
                CreatedDate = DateTime.Now,
                OrderStatus = OrderStatus.Delivered,
                OrderDate = DateTime.Now,
                Status = Status.Active,
                TotalPrice = 310,
            });

        }
    }
}
