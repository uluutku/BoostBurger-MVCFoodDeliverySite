using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;
using YemekSiparis.BLL.Abstract;
using YemekSiparis.BLL.Models.ViewModels;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;

namespace YemekSiparis.Web.Controllers
{
    [Authorize(Roles = "User,Admin")]

    public class BuyController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderBagService _orderBagService;
        private readonly UserManager<AppUser> userManager;
        private readonly ICustomerService customerService;

        public BuyController(IOrderDetailService orderDetailService, IOrderBagService orderBagService, UserManager<AppUser> userManager, ICustomerService customerService)
        {
            _orderDetailService = orderDetailService;
            _orderBagService = orderBagService;
            this.userManager = userManager;
            this.customerService = customerService;
        }

        public async Task<IActionResult> Payment()
        {

            int customerId = await CustomerId();
            OrderBag orderBag = await _orderBagService.GetByWhereAsync(x => x.CustomerId == customerId && x.Status == Status.Active);

            if (orderBag == null)
            {
                ViewBag.EmptyCartWarning = "Sepetiniz şu anda boş.";
                return View(new OrderDetailVM());
            }

            OrderDetailVM orderDetailVM = new OrderDetailVM();
            Expression<Func<OrderDetail, object>>[] includes = new Expression<Func<OrderDetail, object>>[]
            {
                x => x.OrderBag,
                x => x.Beverages,
                x => x.Food,
                x => x.Extras
            };

            orderDetailVM.OrderDetails = await _orderDetailService.AllThenInclude(x => x.OrderBagID == orderBag.Id && x.Status == Status.Active);
            if (orderDetailVM.OrderDetails.Count <= 0)
                await _orderBagService.HardDeleteAsync(orderBag.Id);
            else
            {
                orderBag.TotalPrice = 0;
                foreach (OrderDetail item in orderDetailVM.OrderDetails)
                {
                    orderBag.TotalPrice += item.UnitPrice;
                }

                await _orderBagService.DefaultUpdate(orderBag);
                orderDetailVM.OrderBagId = orderBag.Id;

            }


            return View(orderDetailVM);
        }


        public async Task<IActionResult> DeleteItem(int id)
        {
            await _orderDetailService.HardDeleteAsync(id);
            return RedirectToAction("Payment");
        }


        public async Task<IActionResult> DeleteOrder(int orderBagId)
        {
            List<OrderDetail> orderDetails = await _orderDetailService.GetAllAsync(x => x.OrderBagID == orderBagId);

            foreach (OrderDetail item in orderDetails)
            {
                await _orderDetailService.HardDeleteAsync(item);
            }
            await _orderBagService.HardDeleteAsync(orderBagId);
            return RedirectToAction("Payment");
        }

        public async Task<IActionResult> CompleteOrder()
        {
            int customerId = await CustomerId();
            OrderBag orderBag = await _orderBagService.GetByWhereAsync(x => x.CustomerId == customerId && x.Status == Status.Active);
            orderBag.Status = Status.Passive;
            await _orderBagService.DefaultUpdate(orderBag);

            OrderDetailVM orderDetailVM = new OrderDetailVM();
            orderDetailVM.OrderDetails = await _orderDetailService.AllThenInclude(x => x.OrderBagID == orderBag.Id && x.Status == Status.Active);
            foreach (OrderDetail item in orderDetailVM.OrderDetails)
            {
                item.Status = Status.Passive;
                await _orderDetailService.DefaultUpdateAsync(item);
            }
            return View("OrderCompleted");
        }

        //public  IActionResult ResetTheOrders()
        //{
            
        //    return RedirectToAction("Menu", "Basket");

        //}

        [NonAction]
        public async Task<int> CustomerId()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser appUser = await userManager.FindByIdAsync(userId);
            Customer customer = await customerService.TGetByWhereAsync(x => x.AppUserId == appUser.Id);

            return customer.Id;

        }
    }
}