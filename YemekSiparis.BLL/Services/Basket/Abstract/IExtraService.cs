using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Services.Basket.Abstract
{
    public interface IExtraService : IBaseService<Extra>
    {
        Task<decimal> AdditionAsync(List<Extra> extras = null,List<OrderDetailExtra> detailExtras = null);


        

    }
}
