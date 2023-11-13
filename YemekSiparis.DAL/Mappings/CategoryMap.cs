using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;
namespace YemekSiparis.DAL.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = 1,
                Name = "Hamburger",
                CreatedDate = DateTime.Now,
                Status = Status.Active
            });

            builder.HasData(new Category
            {
                Id = 2,
                Name = "Pizza",
                CreatedDate = DateTime.Now,
                Status = Status.Active
            });
            builder.HasData(new Category
            {
                Id = 3,
                Name = "Makarna",
                CreatedDate = DateTime.Now,
                Status = Status.Active
            });
            builder.HasData(new Category
            {
                Id = 4,
                Name = "Döner",
                CreatedDate = DateTime.Now,
                Status = Status.Active
            });


        }
    }
}
