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
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(new Customer
            {
                Id = 1,
                Name = "Eren ÇOLAK",
                Age = 30,
                Address = "Seyhan /ADANA",
                AppUserId = "1",
                Birthdate = new DateTime(1992, 12, 02),
                CreatedDate = DateTime.Now,
                Gender = Gender.Erkek,
                Status = Status.Active               
            });

 
        }
    }
}
