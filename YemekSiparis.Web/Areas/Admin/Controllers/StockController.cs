using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.BLL.Services.Admin.Bevarage;
using YemekSiparis.BLL.Services.Admin.Extra;
using YemekSiparis.BLL.Services.Admin.Product;
using YemekSiparis.BLL.Services.Admin.Stock;

namespace YemekSiparis.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StockController : Controller
    {
        private readonly IStockService stockService;

        public StockController(IStockService stockService)
        {
            this.stockService = stockService;
        }
        public async Task<IActionResult> Index()
        {
            StockListDTO stockListDTO = await stockService.GetStockList();
            return View(stockListDTO);
        }

        public async Task<IActionResult> UpdateFood(int id, int stock)
        {
           await stockService.UpdateFoodStock(id, stock);
            return RedirectToAction("Stock", "Admin");
        }
        public async Task<IActionResult> UpdateExtra(int id, int stock)
        {
            await stockService.UpdateExtraStock(id, stock);
            return RedirectToAction("Stock", "Admin");
        }
        public async Task<IActionResult> UpdateBeverage(int id, int stock)
        {
            await stockService.UpdateBeverageStock(id, stock);
            return RedirectToAction("Stock", "Admin");
        }
    }
}
