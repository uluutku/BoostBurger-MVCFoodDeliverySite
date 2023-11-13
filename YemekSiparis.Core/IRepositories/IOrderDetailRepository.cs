using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Core.IRepositories
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {

        Task<List<OrderDetail>> AllIncludeOrderDetail(Expression<Func<OrderDetail,bool>> expression = null ,params Expression<Func<OrderDetail,object>>[] include  );

    }
}
