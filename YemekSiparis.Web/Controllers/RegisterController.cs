using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using YemekSiparis.BLL.DTOs.AppUserDTOs;
using YemekSiparis.BLL.ValidationRules.AppUserValidationRules;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace YemekSiparis.Web.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ICustomerRepository _customerRepository;
		private readonly RoleManager<IdentityRole> _roleManager;

		public RegisterController(UserManager<AppUser> userManager, ICustomerRepository customerRepository, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_customerRepository = customerRepository;
			_roleManager = roleManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Index(AppUserRegisterDTO appUserRegisterDTO)
		{

			if (ModelState.IsValid)
			{
				if (appUserRegisterDTO.KullanimSartlari == true)
				{

					Random random = new Random();
					int code = random.Next(100000, 1000000);

					AppUser appUser = new AppUser()
					{
						UserName = appUserRegisterDTO.UserName,
						Email = appUserRegisterDTO.Email,
						PhoneNumber = appUserRegisterDTO.PhoneNumber,
						ConfirmCode = code

					};

					var result = await _userManager.CreateAsync(appUser, appUserRegisterDTO.Password);

					Customer customer = new Customer()
					{
						Name = appUserRegisterDTO.Name,
						Address = appUserRegisterDTO.Address,
						AppUserId = appUser.Id
					};



					if (result.Succeeded)
					{
						await _customerRepository.AddAsync(customer);

						IdentityRole adminRole = await _roleManager.FindByNameAsync("User");
						await _userManager.AddToRoleAsync(appUser, adminRole.Name);



						MimeMessage mimeMessage = new MimeMessage();
						MailboxAddress mailboxAddressFrom = new MailboxAddress("YemekSepetiAdmin", "dproje.4@hotmail.com");
						MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

						mimeMessage.From.Add(mailboxAddressFrom);
						mimeMessage.To.Add(mailboxAddressTo);

						var bodyBuilder = new BodyBuilder();
						//bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz: " + code;

						bodyBuilder.HtmlBody = @"<!DOCTYPE html>
									 <html lang='tr'>
									 <head>
										 <meta charset='UTF-8'>
										 <meta name='viewport' content='width=device-width, initial-scale=1.0'>
										 <title>Yemek Sepeti Hesap Doğrulama</title>
										 <style>
											body {
												font-family: Arial, sans-serif;
												color: #333;
											}
											.container {
												background-color: #f4f4f4;
												padding: 20px;
												border: 1px solid #ddd;
											}
											.code {
												font-size: 20px;
												padding: 10px;
												border: 1px solid #ddd;
												display: inline-block;
												background-color: #fff;
											}
										</style>
									</head>
									<body>
										<div class='container'>
											<h2>Yemek Sepeti Hesap Doğrulama</h2>
											<p>Merhaba,</p>
											<p>Yemek Sepeti hesabınızı doğrulamak için aşağıdaki doğrulama kodunu kullanın:</p>
											<div class='code'>" + code + @"</div>											
											<p>İyi günler dileriz.</p>
										</div>
									</body>
									</html>";

						mimeMessage.Body = bodyBuilder.ToMessageBody();

						mimeMessage.Subject = "Yemek Sepeti Onay Kodu";

						SmtpClient client = new SmtpClient();
						client.Connect("smtp.office365.com", 587, false);
						client.Authenticate("dproje.4@hotmail.com", "123456789aA*");
						client.Send(mimeMessage);
						client.Disconnect(true);

						
						HttpContext.Session.SetString("mail", appUserRegisterDTO.Email);

						return RedirectToAction("Index", "ConfirmMail");
					}
					else
					{
						foreach (var item in result.Errors)
						{
							ModelState.AddModelError("", item.Description);
						}
					}


				}
				else
					ModelState.AddModelError("", "Kullanım Şartları Kabul Edilmedi!");

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
