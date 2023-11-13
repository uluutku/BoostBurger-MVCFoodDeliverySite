using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;
using YemekSiparis.DAL.Context;

namespace YemekSiparis.DAL.SeedData
{
	public class AdminSeedData
	{

		public static async void Seed(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext _context)
		{

			if (!_context.Roles.Any(r => r.Name == "Admin"))
			{
				IdentityRole adminRole = new IdentityRole { Name = "Admin" };
				roleManager.CreateAsync(adminRole).Wait();
			}

			if (!_context.Roles.Any(r => r.Name == "User"))
			{
				IdentityRole userRole = new IdentityRole { Name = "User" };
				roleManager.CreateAsync(userRole).Wait();
			}

			if (!_context.Users.Any(u => u.UserName == "erencolk"))
			{

				AppUser user = new AppUser
				{
					UserName = "erencolk",
					Email = "eren.colk@gmail.com",
					EmailConfirmed = true,
				};

				userManager.CreateAsync(user, "Eren12345.").Wait();


				AppUser createdUser = await userManager.FindByNameAsync("erencolk");


				IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
				await userManager.AddToRoleAsync(createdUser, adminRole.Name);
			}

		}


	}
}
