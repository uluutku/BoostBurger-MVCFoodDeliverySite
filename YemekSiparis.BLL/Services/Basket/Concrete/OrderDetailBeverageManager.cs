using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Helper;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Context;
using YemekSiparis.DAL.Repositories;

namespace YemekSiparis.BLL.Services.Basket.Concrete
{
    public class OrderDetailBeverageManager : IOrderDetailBeverageService
    {
        private readonly IOrderDetailBeverageRepository _db;

        public OrderDetailBeverageManager(IOrderDetailBeverageRepository db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(OrderDetailBeverage orderDetail)
        {
            if (orderDetail == null)
                return false;
            else
                return await _db.AddAsync(orderDetail);
        }

        public async Task<bool> AddBeverageToOrder(OrderDetailBeverage beverage,int orderDetailId)
        {
            if (beverage == null)
                return false;
            else
                foreach (Beverage item in BeverageData.Beverages)
                {
                    beverage.OrderDetailID = orderDetailId;
                    beverage.BeverageID = item.Id;
                   bool result = await _db.AddAsync(beverage);
                    if (!result)
                    {
                        return false;                       
                    }
                }
            return true;

        }
    }
}
