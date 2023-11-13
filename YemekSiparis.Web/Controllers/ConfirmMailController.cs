using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MimeKit;
using YemekSiparis.BLL.DTOs.AppUserDTOs;
using YemekSiparis.BLL.VMs;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Web.Controllers
{
	public class ConfirmMailController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		const string mail = "mail";

		public ConfirmMailController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}


		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(ConfirmMailVM confirmMailVM)
		{

			var user = await _userManager.FindByEmailAsync(HttpContext.Session.GetString("mail"));
			if (user.ConfirmCode == confirmMailVM.ConfirmCode)
			{
				user.EmailConfirmed = true;
				await _userManager.UpdateAsync(user);
				HttpContext.Session.Remove("mail");
				return RedirectToAction("Index", "Login");

			}
			else
			{
				ModelState.AddModelError("", "Doğrulama Kodu Başarısız");
			}

			return View();
		}		



	}
}
