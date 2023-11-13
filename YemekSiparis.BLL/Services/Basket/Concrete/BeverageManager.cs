using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Services.Basket.Concrete
{
    public class BeverageManager : BaseManager<Beverage>, IBeverageService
    {
        private readonly IBaseRepository<Beverage> _baseRepository;
        public BeverageManager(IBaseRepository<Beverage> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
           
        }

        public async Task<decimal> AdditionAsync(List<Beverage> beverages = null, List<OrderDetailBeverage> detailBeverages = null)
        {
            decimal total = 1;

            if (detailBeverages == null)
            {
                foreach (Beverage item in beverages)
                {
                    total += item.Price;
                }

            }
            else if (beverages == null)
            {
                foreach (OrderDetailBeverage item in detailBeverages)
                {
                    Beverage beverage = await _baseRepository.GetByIdAsync(item.BeverageID);
                    total += beverage.Price;

                }

            }



            return total;

        }
    }
}
