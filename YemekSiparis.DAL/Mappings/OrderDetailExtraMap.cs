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
    public class OrderDetailExtraMap : IEntityTypeConfiguration<OrderDetailExtra>
    {
        public void Configure(EntityTypeBuilder<OrderDetailExtra> builder)
        {
            builder.HasKey(x => new { x.OrderDetailID, x.ExtraID });

            builder.HasData(new OrderDetailExtra
            {
                ExtraID = 1,
                OrderDetailID = 1,

            });

            builder.HasData(new OrderDetailExtra
            {
                ExtraID = 2,
                OrderDetailID = 1,
            });
            builder.HasData(new OrderDetailExtra
            {
                ExtraID = 3,
                OrderDetailID = 1,

            });

        }
    }
}
