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
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(new Employee
            {
                Id = 1,
                Name = "Cabbar HÜSEYİN",
                Address = "Şakirpaşa/ADANA",
                Role = "Kasiyer",
                Shift = "Gündüz",
                CreatedDate = DateTime.Now,
                Status = Status.Active,
                Salary = 11.500m
            });
            builder.HasData(new Employee
            {
                Id = 2,
                Name = "Ayşe FATMA",
                Address = "Hürriyet/ADANA",
                Role = "Temizlikçi",
                Shift = "Gündüz",
                CreatedDate = DateTime.Now,
                Status = Status.Active,
                Salary = 11.500m
            });

        }
    }
}
