using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YemekSiparis.BLL.VMs;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
			_roleManager = roleManager;
		}


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVM loginVM)
        {
            var result = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password,loginVM.RememberMe,true);
            if (result.Succeeded)
            {

				var user = await _userManager.FindByNameAsync(loginVM.UserName);
                if (user.EmailConfirmed == true)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var currentRole = roles[0];

                    if (currentRole == "User")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (currentRole == "Admin")
                    {
                        return RedirectToAction("Home", "Admin");
                    }
                }
                else if(user.EmailConfirmed == false)
                {
                    await _userManager.DeleteAsync(user);
                    ModelState.AddModelError("", "Doğrulanmamış Email. Tekrar Kayıt Olunuz!");
                    return View();
                }
                
            }
            ModelState.AddModelError("", "Kullanıcı Adı ya da parola hatalı!");
            return View();
        }


        public async Task<IActionResult> Logout()
        {

           await  _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
