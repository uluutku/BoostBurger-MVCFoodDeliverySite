using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.ViewModels;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Services.Basket.Abstract
{
    public interface IOrderDetailService : IOrderDetailRepository
    {

        //Task<bool> CreateDetailVM(CreateOrderDetailVM vm);

        Task<bool> DefaultUpdateAsync(OrderDetail orderDetail);

        Task<List<OrderDetail>> AllIncludeOrderDetail(Expression<Func<OrderDetail, bool>> expression = null, params Expression<Func<OrderDetail, object>>[] include);
        Task<List<OrderDetail>> AllThenInclude(Expression<Func<OrderDetail, bool>> expression = null);

    
    }
}
