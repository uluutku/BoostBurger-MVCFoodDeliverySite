using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Services.Basket.Abstract
{
    public interface IBeverageService : IBaseService<Beverage>
    {

        Task<decimal> AdditionAsync(List<Beverage> beverages = null, List<OrderDetailBeverage> detailBeverages = null);

    

    }
}
