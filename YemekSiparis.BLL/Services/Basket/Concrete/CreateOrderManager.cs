using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.ViewModels;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.Core.Enums;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Services.Basket.Concrete
{
    public class CreateOrderManager : ICreateOrderService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IExtraRepository _extraRepository;
        private readonly IBeverageRepository _beverageRepository;
        private readonly IFoodService _foodService;

        public CreateOrderManager(IFoodRepository foodRepository, IExtraRepository extraRepository, IBeverageRepository beverageRepository,IFoodService foodService)
        {
            _foodRepository = foodRepository;
            _extraRepository = extraRepository;
            _beverageRepository = beverageRepository;
            _foodService = foodService;
        }


        public async Task<CreateOrderDetailVM> CreateAsync(int id)
        {

            CreateOrderDetailVM createVM = new CreateOrderDetailVM();
            createVM.FoodId =  _foodRepository.GetByWhereAsync(x => x.Id == Convert.ToInt32(id)).Result.Id;
            createVM.Food = await _foodRepository.GetByWhereAsync(x => x.Id == Convert.ToInt32(id));
            createVM.Food.ClickCount += 1;
            createVM.Beverages = await _beverageRepository.GetAllAsync(x=>x.Status == Status.Active);
            createVM.Extras = await _extraRepository.GetAllAsync(x => x.Status == Status.Active);
            await _foodService.DefaultUpdate(createVM.Food);
            return createVM;
        }
    }
}
