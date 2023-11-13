using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using YemekSiparis.BLL.VMs;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Web.Controllers
{
	[AllowAnonymous]
	public class ChangePasswordController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;

		public ChangePasswordController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult ForgetPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPasswordVM)
		{
			var user = await _userManager.FindByEmailAsync(forgetPasswordVM.Mail);
			string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
			var passwordResetTokenLink = Url.Action("ResetPassword", "ChangePassword", new
			{
				userId = user.Id,
				token = passwordResetToken
			}, HttpContext.Request.Scheme);

			MimeMessage mimeMessage = new MimeMessage();
			MailboxAddress mailboxAddressFrom = new MailboxAddress("YemekSepetiAdmin", "dproje.4@hotmail.com");
			MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordVM.Mail);

			mimeMessage.From.Add(mailboxAddressFrom);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();


			bodyBuilder.TextBody = passwordResetTokenLink;

			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = "Şifre Değişiklik Talebi";

			SmtpClient client = new SmtpClient();
			client.Connect("smtp.office365.com", 587, false);
			client.Authenticate("dproje.4@hotmail.com", "123456789aA*");
			client.Send(mimeMessage);
			client.Disconnect(true);



			return View();
		}

		[HttpGet]
		public IActionResult ResetPassword(string userid, string token)
		{
			TempData["userid"] = userid;
			TempData["token"] = token;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
		{
			var userid = TempData["userid"];
			var token = TempData["token"];

			if(ModelState.IsValid)
			{
				if (userid == null || token == null)
				{
					ModelState.AddModelError("", "Hata");
					return View();
				}

				var user = await _userManager.FindByIdAsync(userid.ToString());
				var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordVM.Password);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				}
				else
				{
					ModelState.AddModelError("", "Başarısız");
					return View(result);
				}
			}
			else
			{
				foreach (var key in ModelState.Keys)
				{
					var errors = ModelState[key].Errors;
					foreach (var error in errors)
					{

						var errorMessage = error.ErrorMessage;
						ModelState.AddModelError("", errorMessage);
					}
				}
			}



			return View();
		}

		


	}
}
