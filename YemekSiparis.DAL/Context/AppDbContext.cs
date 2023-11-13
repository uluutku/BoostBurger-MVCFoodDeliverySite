using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;


namespace YemekSiparis.DAL.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<OrderBag> OrderBags { get; set; }
        public DbSet<OrderDetailBeverage> OrderDetailBeverages { get; set; }
        public DbSet<OrderDetailExtra> OrderDetailExtras{ get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<FoodDiet> FoodDiets { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

    }
}
