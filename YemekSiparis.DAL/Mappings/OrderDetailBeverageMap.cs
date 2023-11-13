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
    public class OrderDetailBeverageMap : IEntityTypeConfiguration<OrderDetailBeverage>
    {
        public void Configure(EntityTypeBuilder<OrderDetailBeverage> builder)
        {
            builder.HasKey(x => new { x.BeverageID, x.OrderDetailID });

            builder.HasData(new OrderDetailBeverage
            {
                BeverageID = 1,
                OrderDetailID = 1,

            });
            builder.HasData(new OrderDetailBeverage
            {
                BeverageID = 2,
                OrderDetailID = 1,

            });
        }
    }
}
