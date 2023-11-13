using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekSiparis.BLL.Services.Admin.Giro;

namespace YemekSiparis.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GiroController : Controller
    {
        private readonly IGiroService giroService;

        public GiroController(IGiroService giroService)
        {
            this.giroService = giroService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await giroService.GetAll());
        }
    }
}
