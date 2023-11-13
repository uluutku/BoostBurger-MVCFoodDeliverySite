using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.BLL.Services.Basket.Concrete;
using YemekSiparis.BLL.Abstract;
using YemekSiparis.BLL.Concrete;

using YemekSiparis.BLL.Services.Admin.Bevarage;
using YemekSiparis.BLL.Services.Admin.Beverage;
using YemekSiparis.BLL.Services.Admin.Category;
using YemekSiparis.BLL.Services.Admin.CustomerDetail;
using YemekSiparis.BLL.Services.Admin.Employee;
using YemekSiparis.BLL.Services.Admin.Extra;
using YemekSiparis.BLL.Services.Admin.Giro;
using YemekSiparis.BLL.Services.Admin.Product;
using YemekSiparis.BLL.Services.Admin.Stock;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Context;
using YemekSiparis.DAL.Repositories;
using YemekSiparis.DAL.SeedData;
using YemekSiparis.Web.Models;
using YemekSiparis.BLL.AutoMapper;

namespace YemekSiparis.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });



            //Session
            builder.Services.AddSession();
            

            //CONTEXT
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conStr")));

            //IDENTÝTY
            builder.Services.AddIdentity<AppUser, IdentityRole>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<AppDbContext>().AddErrorDescriber<CustomIdentityValidation>();//AddErrorDescriber eklendi

			builder.Services.Configure<IdentityOptions>(options =>
			{
				options.User.RequireUniqueEmail = true;
				
			});

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.AccessDeniedPath = "/Home/Index";
                options.LoginPath = "/Login/Index"; 

            });

            //MAPPER
            builder.Services.AddAutoMapper(typeof(MappingProfile));



            //Repo
            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddTransient(typeof(IFoodDietRepository), typeof(FoodDietRepository));
            builder.Services.AddTransient(typeof(ICustomerDetailRepository), typeof(CustomerDetailRepository));
            builder.Services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepository));
            builder.Services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            builder.Services.AddTransient<IFoodRepository, FoodRepository>();
            builder.Services.AddTransient<IExtraRepository, ExtraRepository>();
            builder.Services.AddTransient<IBeverageRepository, BeverageRepository>();
            builder.Services.AddTransient<IOrderBagRepository, OrderBagRepository>();
            builder.Services.AddTransient<IOrderDetailBeverageRepository, OrderDetailBeverageRepository>();
            builder.Services.AddTransient<IOrderDetailExtraRepository, OrderDetailExtraRepository>();
            builder.Services.AddTransient<IOrderBagRepository, OrderBagRepository>();
            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

            //Services
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IExtraAdminService, ExtraAdminService>();
            builder.Services.AddScoped<IBeverageAdminService, BeverageAdminService>();
            builder.Services.AddScoped<IStockService, StockService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICustomerDetailService, CustomerDetailService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IGiroService, GiroService>();
            builder.Services.AddScoped<ICreateOrderService,CreateOrderManager>();
            builder.Services.AddScoped<IOrderDetailService,OrderDetailManager>();
            builder.Services.AddScoped<IExtraService,ExtraManager>();
            builder.Services.AddScoped<IBeverageService,BeverageManager>();
            builder.Services.AddScoped<IOrderDetailBeverageService,OrderDetailBeverageManager>();
            builder.Services.AddScoped<IOrderDetailExtraService,OrderDetailExtraManager>();
            builder.Services.AddScoped<IOrderBagService,OrderBagManager>();
            builder.Services.AddScoped<IFoodService,FoodManager>();
            builder.Services.AddScoped<ICustomerService,CustomerManager>();


            //Automapper
            //builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var app = builder.Build();
            var serviceScope = app.Services.CreateScope();

            AppDbContext _context = serviceScope.ServiceProvider.GetService<AppDbContext>();
            UserManager<AppUser> userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

            AdminSeedData.Seed(userManager, roleManager, _context);


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); 
            app.UseAuthorization();


            app.UseSession(); //Eklendi

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}