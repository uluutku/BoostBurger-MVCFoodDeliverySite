using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.BLL.Services.Admin.Product;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            List<FoodListDTO> foodlist = await productService.GetFoodList();
            return View(foodlist);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await productService.GetCategories();
            ProductCreateDTO productCreate = new();
            productCreate.Diets = await productService.GetDiets();
            return View(productCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            if (ModelState.IsValid)
            {
                await productService.CreateFood(productCreateDTO);
                return RedirectToAction("Product", "Admin");
            }
            ViewBag.Categories = await productService.GetCategories();
            return View(productCreateDTO);
        }

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Categories = await productService.GetCategories();
            return View(await productService.GetUpdateFood(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                await productService.PostUpdateFood(productUpdateDTO);
                return RedirectToAction("Product", "Admin");
            }
            ViewBag.Categories = await productService.GetCategories();
            return View(productUpdateDTO);

        }

        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteFood(id);
            return RedirectToAction("Product", "Admin");
        }
    }
}
