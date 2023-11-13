using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YemekSiparis.BLL.Services.Admin.CustomerDetail;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CustomerDetailController : Controller
    {
        private readonly ICustomerDetailService customerDetailService;

        public CustomerDetailController(ICustomerDetailService customerDetailService)
        {
            this.customerDetailService = customerDetailService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await customerDetailService.GetAll());
        }
    }
}
