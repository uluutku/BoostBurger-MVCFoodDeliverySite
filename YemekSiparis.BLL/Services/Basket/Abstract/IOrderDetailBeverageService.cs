using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Services.Basket.Abstract
{
    public interface IOrderDetailBeverageService : IOrderDetailBeverageRepository
    {

        Task<bool> AddBeverageToOrder(OrderDetailBeverage beverage, int orderDetailId);

    }
}
