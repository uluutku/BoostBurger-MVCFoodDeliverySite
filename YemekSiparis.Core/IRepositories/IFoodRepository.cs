using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Core.IRepositories
{
    public interface IFoodRepository : IBaseRepository<Food>
    {

        Task<List<Food>> AllIncludeFood(Expression<Func<Food,bool>> exp = null ,params Expression<Func<Food, object>>[] include);
        Task<Food> GetByIncludeFood(Expression<Func<Food,bool>> exp = null ,params Expression<Func<Food, object>>[] include);

        Task<Food> GetByAllInclude(Expression<Func<Food, bool>> exp);
    }
}
