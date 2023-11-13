using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;
using YemekSiparis.BLL.Abstract;
using YemekSiparis.BLL.Helper;
using YemekSiparis.BLL.Models.ViewModels;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.Web.Controllers
{
    [Authorize(Roles ="User,Admin")]
    public class BasketController : Controller
    {
        private readonly IBaseRepository<Category> _baseRepository;
        private readonly IExtraRepository _extraRepository;
        private readonly IBeverageRepository _beverageRepository;
        private readonly IFoodRepository _foodRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOrderBagRepository _orderBagRepository;
        private readonly ICreateOrderService _createOrderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IExtraService _extraService;
        private readonly IBeverageService _beverageService;
        private readonly IOrderDetailBeverageService _orderBeverageService;
        private readonly IOrderDetailExtraService _orderExtraService;
        private readonly IOrderBagService _orderBagService;
        private readonly IMapper _mapper;
        private readonly ICustomerService customerService;

        public BasketController(IBaseRepository<Category> baseRepository, IExtraRepository extraRepository, IBeverageRepository beverageRepository, IFoodRepository foodRepository, IOrderDetailRepository orderDetailRepository, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOrderBagRepository orderBagRepository, ICreateOrderService createOrderService, IOrderDetailService orderDetailService, IExtraService extraService, IBeverageService beverageService, IOrderDetailBeverageService orderBeverageService, IOrderDetailExtraService orderExtraService, IOrderBagService orderBagService, IMapper mapper, ICustomerService customerService)
        {
            _baseRepository = baseRepository;
            _extraRepository = extraRepository;
            _beverageRepository = beverageRepository;
            _foodRepository = foodRepository;
            _orderDetailRepository = orderDetailRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _orderBagRepository = orderBagRepository;
            _createOrderService = createOrderService;
            _orderDetailService = orderDetailService;
            _extraService = extraService;
            _beverageService = beverageService;
            _orderBeverageService = orderBeverageService;
            _orderExtraService = orderExtraService;
            _orderBagService = orderBagService;
            _mapper = mapper;
            this.customerService = customerService;
        }

        public async Task<IActionResult> Menu()
        {
            List<Category> categories = await _baseRepository.GetAllAsync();

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> AllMenu(int id)
        {
            Expression<Func<Food, object>>[] includes = new Expression<Func<Food, object>>[]
                {
              x=> x.Category, x=> x.Diets
                };
            if (id == 0)
            {
                ListFoodVM listFoodVM = new ListFoodVM();
                listFoodVM.Foods = await _foodRepository.AllIncludeFood(x => x.Status != Status.Passive , includes);
                return PartialView("_MenuPartialView", listFoodVM);
            }
            else
            {
                ListFoodVM listFoodVM = new ListFoodVM();
                listFoodVM.Foods = await _foodRepository.AllIncludeFood(x => x.CategoryID == id && x.Status != Status.Passive, includes);
                return PartialView("_MenuPartialView", listFoodVM);
            }
        }

        public async Task<IActionResult> CreateOrder(int id)
        {
            CreateOrderDetailVM vm = await _createOrderService.CreateAsync(id);
            if (vm == null)
                return RedirectToAction("Menu");
            else
                return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDetailVM detailVM)
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Customer customer = new Customer();
            customer.Id = await customerService.GetCustomerId(userId);

            OrderBag bag = await _orderBagRepository.GetByWhereAsync(x => x.CustomerId == customer.Id && x.Status == Status.Active);

            OrderDetail orderDetail = new OrderDetail();
            if (bag == null)
            {
                bag = await _orderBagService.GetOrderBagID(customer.Id);
                orderDetail.OrderBagID = bag.Id;
            }
            else
                orderDetail.OrderBagID = bag.Id;


            orderDetail.Quantity = detailVM.Quantity;
            orderDetail.FoodID = detailVM.FoodId;
            orderDetail.FoodSize = detailVM.FoodSize;
            await _orderDetailService.AddAsync(orderDetail);


            OrderDetailExtra extra = new OrderDetailExtra();
            await _orderExtraService.AddExtraToOrder(extra, orderDetail.Id);

            OrderDetailBeverage beverage = new OrderDetailBeverage();
            await _orderBeverageService.AddBeverageToOrder(beverage, orderDetail.Id);

            Expression<Func<OrderDetail, object>>[] includes = new Expression<Func<OrderDetail, object>>[]
            {
                x=>x.Beverages, x=>x.Extras,x=>x.Food
            };

            //SEPETE TOPLAM FİYAT EKLE
            bag.TotalPrice = await _orderBagService.TotalPayment(await _orderDetailRepository.AllIncludeOrderDetail(x => x.Status == Status.Active && x.OrderBagID == bag.Id, includes));
            await _orderBagService.DefaultUpdate(bag);

            //SİPARİŞE TOPLAM FİYAT EKLE
            orderDetail.UnitPrice = await _orderBagService.TotalPayment(await _orderDetailRepository.AllIncludeOrderDetail(x => x.Id == orderDetail.Id && x.Status == Status.Active, includes));

            await _orderDetailService.DefaultUpdateAsync(orderDetail);

            TempData["Success"] = "Ürün Sepete Eklendi";

            DataClear.Clear();
            return RedirectToAction("Menu");
        }



        [HttpPost]
        public async Task<IActionResult> TotalPrice(CreateOrderDetailVM detailVM)
        {

            Food food = await _foodRepository.GetByAllInclude(x => x.Id == detailVM.FoodId);

            if ((detailVM.ExtraId != 0) && detailVM.IsSelected == true)
                ExtraData.Extras.Add(await _extraRepository.GetByIdAsync(detailVM.ExtraId));

            else if ((detailVM.ExtraId != 0) && detailVM.IsSelected == false)
            {
                Extra extra = new Extra();

                foreach (var element in ExtraData.Extras)
                {
                    if (element.Id == detailVM.ExtraId)
                    {
                        extra = element;
                        break;
                    }
                }
                ExtraData.Extras.Remove(extra);
            }

            if (detailVM.BeverageId != 0 && detailVM.IsSelected == true)
                BeverageData.Beverages.Add(await _beverageRepository.GetByIdAsync(detailVM.BeverageId));
            else if (detailVM.BeverageId != 0 && detailVM.IsSelected == false)
            {
                Beverage beverage = new Beverage();

                foreach (var element in BeverageData.Beverages)
                {
                    if (element.Id == detailVM.BeverageId)
                    {
                        beverage = element;
                        break;
                    }
                }
                BeverageData.Beverages.Remove(beverage);
            }
            decimal size = FoodSizeResult.SizePrice(detailVM.FoodSize);

            if (ExtraData.Extras.Count <= 0 && BeverageData.Beverages.Count <= 0)
                detailVM.TotalPrice = Math.Round((food.Price * (1 - food.Discount)) * detailVM.Quantity * size ,2);
            else if (ExtraData.Extras.Count > 0 && BeverageData.Beverages.Count <= 0)
                detailVM.TotalPrice = Math.Round((food.Price * (1 - food.Discount)) * detailVM.Quantity * size + await _extraService.AdditionAsync(ExtraData.Extras), 2);
            else if (BeverageData.Beverages.Count > 0 && ExtraData.Extras.Count <= 0)
                detailVM.TotalPrice = Math.Round((food.Price * (1 - food.Discount)) * detailVM.Quantity * size + await _beverageService.AdditionAsync(BeverageData.Beverages), 2);
            else
                detailVM.TotalPrice = Math.Round((food.Price * (1 - food.Discount)) * detailVM.Quantity * size + await _extraService.AdditionAsync(ExtraData.Extras) + await _beverageService.AdditionAsync(BeverageData.Beverages), 2);

            return PartialView("_TotalPricePartial", detailVM);


        }


    }
}

