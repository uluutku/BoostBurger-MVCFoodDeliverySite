using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;
using YemekSiparis.BLL.Abstract;
using YemekSiparis.BLL.Models.ViewModels;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.BLL.Validations;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;

namespace YemekSiparis.Web.Controllers
{
    [Authorize(Roles = "User,Admin")]

    public class UserProfile : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly IOrderBagService _orderBagService;
        private readonly IOrderDetailService _orderDetailService;

        public UserProfile(UserManager<AppUser> userManager, ICustomerService customerService, IMapper mapper,IOrderBagService orderBagService,IOrderDetailService orderDetailService)
        {
            _userManager = userManager;
            _customerService = customerService;
            _mapper = mapper;
            _orderBagService = orderBagService;
            _orderDetailService = orderDetailService;
        }

        public IActionResult Index()
        {
            HttpContext.Response.Cookies.Append("CustomerId", "1");

            return RedirectToAction("ProfileDetail");
        }


        [HttpGet]
        public async Task<IActionResult> ProfileDetail()
        {
            Customer customer = new Customer();
            int customerId = await CustomerId();
            customer = await _customerService.TGetByIdAsync(customerId);
            return View(customer);
        }

        public async Task<IActionResult> ProfileUpdate(int id)
        {

            Customer customer = await _customerService.TGetByIdAsync(id);
            return View(customer);

        }


        [HttpPost]
        public async Task<IActionResult> ProfileUpdate(CustomerVM customerVM)
        {
            CustomerVMValidator validationRules = new CustomerVMValidator();

            var result = validationRules.Validate(customerVM);
            Customer customer = _mapper.Map<Customer>(customerVM);
            customer.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

       

            if (result.IsValid)
            {                
                await _customerService.TUpdateAsync(customer);
                return RedirectToAction("ProfileDetail");
            }
            ModelState.Clear();
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View(customer);
        }

        //TODOO SİPARİŞLERİ GÖRÜNTÜLEYİ YAP VE BASKET CONTROLLERDA GELEN NESNELERİ ACTİVE OLUP OLMAIDINGA GÖRE KONTROL ET

        public async Task<IActionResult> Orders()
        {
            Expression<Func<OrderBag, object>>[] includes = new Expression<Func<OrderBag, object>>[]
            {
                x=>x.Customer,x=>x.OrderDetails

            };

            int id = await CustomerId();

            List<OrderBag> orders = await _orderBagService.GetAllIncludeOrderss(x => x.CustomerId == id, includes);

            OrderDetailVM orderDetail = new OrderDetailVM();
           
            foreach (OrderBag item in orders) 
            {
                orderDetail.OrderDetails.AddRange(await _orderDetailService.AllThenInclude(x => x.OrderBagID == item.Id && x.Status == Status.Passive));
            }
            return View(orderDetail);
        }


        public async Task<IActionResult> OrderHardDelete(int id)
        {
            await _orderDetailService.HardDeleteAsync(id);

            return  RedirectToAction("Orders");
        }



        [NonAction]
        public async Task<int> CustomerId()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUser appUser = await _userManager.FindByIdAsync(userId);
            Customer customer = await _customerService.TGetByWhereAsync(x => x.AppUserId == appUser.Id);

            return customer.Id;

        }



    }
}
