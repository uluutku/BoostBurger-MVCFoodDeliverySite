using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Helper;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Services.Basket.Concrete
{
    public class OrderDetailExtraManager : IOrderDetailExtraService
    {
        private readonly IOrderDetailExtraRepository _db;

        public OrderDetailExtraManager(IOrderDetailExtraRepository db)
        {
            _db = db;
        }
        public async Task<bool> AddAsync(OrderDetailExtra extra)
        {
            if (extra == null)
                return false;
            else
                return await _db.AddAsync(extra);

        }

        public async Task<bool> AddExtraToOrder(OrderDetailExtra extra, int orderDetailId)
        {

            if (extra == null)
                return false;
            else
                foreach (Extra item in ExtraData.Extras)
                {
                    extra.OrderDetailID = orderDetailId;
                    extra.ExtraID = item.Id;
                    bool result = await _db.AddAsync(extra);
                    if (!result)
                    {
                        return false;
                    }
                }
            return true;


        }
    }
}
