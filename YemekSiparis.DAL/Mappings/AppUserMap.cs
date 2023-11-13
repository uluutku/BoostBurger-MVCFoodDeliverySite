using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;
using YemekSiparis.DAL.Context;

namespace YemekSiparis.DAL.Mappings
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {


        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            builder.HasData(new AppUser
            {
                Id = "1",
                Email = "eren.colk01@gmail.com",
                UserName = "erencolak",
           
            });

 


        }
    }
}
