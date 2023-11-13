using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekSiparis.BLL.Services.Admin.Category;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await categoryService.getAllCategories());
        }

        public async Task<IActionResult> Update(int id, string Name)
        {
            await categoryService.UpdateCategory(id,Name);
            return RedirectToAction("Category", "Admin");
        }

        public async Task<IActionResult> Create(string name)
        {
            await categoryService.AddCategory(name);
            return RedirectToAction("Category", "Admin");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await categoryService.DeleteCategory(id);
            return RedirectToAction("Category", "Admin");
        }
    }
}
