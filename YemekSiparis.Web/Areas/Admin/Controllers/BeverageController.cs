using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.BLL.Services.Admin.Bevarage;

namespace YemekSiparis.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BeverageController : Controller
    {
        private readonly IBeverageAdminService beverageService;

        public BeverageController(IBeverageAdminService beverageService)
        {
            this.beverageService = beverageService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await beverageService.GetExtras());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BeverageCreateDTO beverageCreate)
        {
            if (ModelState.IsValid)
            {
                bool result = await beverageService.AddExtra(beverageCreate);
                if (result == false)
                    return View(beverageCreate);
                return RedirectToAction("Beverage","Admin");
            }
                return View(beverageCreate);
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await beverageService.getExtra(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(BeverageUpdateDTO beverageUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                bool result = await beverageService.UpdateExtra(beverageUpdateDTO);
                if (result == false)
                    return View(beverageUpdateDTO);
                return RedirectToAction("Beverage", "Admin");
            }
            return View(beverageUpdateDTO);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await beverageService.DeleteExtra(id);
            return RedirectToAction("Beverage", "Admin");
        }
    }
}
