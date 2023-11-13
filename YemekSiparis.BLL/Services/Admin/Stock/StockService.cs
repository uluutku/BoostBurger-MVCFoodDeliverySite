using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Services.Admin.Stock
{
    public class StockService : IStockService
    {
        private readonly IBaseRepository<Food> foodRepository;
        private readonly IBaseRepository<Core.Entities.Extra> extraRepository;
        private readonly IBaseRepository<Core.Entities.Beverage> beverageRepository;
        private readonly IMapper mapper;

        public StockService(IBaseRepository<Food> foodRepository, IBaseRepository<Core.Entities.Extra> extraRepository, IBaseRepository<Core.Entities.Beverage> beverageRepository, IMapper mapper)
        {
            this.foodRepository = foodRepository;
            this.extraRepository = extraRepository;
            this.beverageRepository = beverageRepository;
            this.mapper = mapper;
        }
        public async Task<StockListDTO> GetStockList()
        {
            List<Food> foods = await foodRepository.GetAllAsync(x=> x.Status != Status.Passive);
            List<Core.Entities.Extra> extras = await extraRepository.GetAllAsync(x => x.Status != Status.Passive);
            List<Core.Entities.Beverage> beverages = await beverageRepository.GetAllAsync(x => x.Status != Status.Passive);

            StockListDTO stockList = new StockListDTO()
            {
                Foods = mapper.Map<List<StockProductsDTO>>(foods),
                Extras = mapper.Map<List<StockProductsDTO>>(extras),
                Beverages = mapper.Map<List<StockProductsDTO>>(beverages)    
            };
            return stockList;
        }

        public async Task<bool> UpdateBeverageStock(int id, int stock)
        {
            Core.Entities.Beverage beverage = await beverageRepository.GetByIdAsync(id);
            beverage.Stock = stock;
            return await beverageRepository.UpdateAsync(beverage);
        }

        public async Task<bool> UpdateExtraStock(int id, int stock)
        {
            Core.Entities.Extra extra = await extraRepository.GetByIdAsync(id);
            extra.Stock = stock;
            return await extraRepository.UpdateAsync(extra);
        }

        public async Task<bool> UpdateFoodStock(int id, int stock)
        {
            Food food = await foodRepository.GetByIdAsync(id);
            food.Stock = stock;
            return await foodRepository.UpdateAsync(food);
        }
    }
}
