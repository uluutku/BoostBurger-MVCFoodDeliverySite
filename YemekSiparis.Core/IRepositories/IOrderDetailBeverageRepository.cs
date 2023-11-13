using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Core.IRepositories
{
    public interface IOrderDetailBeverageRepository 
    {

        Task<bool> AddAsync(OrderDetailBeverage orderDetail);


    }
}
