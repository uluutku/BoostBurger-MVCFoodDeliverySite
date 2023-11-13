using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.BLL.Services.Basket.Abstract
{
    public interface IBaseService <T>
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> HardDeleteAsync(T entity);
        Task<bool> HardDeleteAsync(int id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp = null);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByWhereAsync(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);

    }
}
