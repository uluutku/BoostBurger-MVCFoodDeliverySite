using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Core.IRepositories
{
    public interface IOrderBagRepository : IBaseRepository<OrderBag>
    {
        Task<List<OrderBag>> AllIncludeOrderBag(params Expression<Func<OrderBag, object>>[] include);
      
    }
}
