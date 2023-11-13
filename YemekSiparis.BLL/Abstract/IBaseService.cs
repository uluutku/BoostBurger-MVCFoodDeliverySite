using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.BLL.Abstract
{
    public interface IBaseService<T> where T : class
    {
        Task<bool> TAddAsync(T entity);
        Task<bool> TUpdateAsync(T entity);
        Task<bool> TDeleteAsync(T entity);
        Task<bool> TDeleteAsync(int id);
        Task<bool> THardDeleteAsync(T entity);
        Task<bool> THardDeleteAsync(int id);
        Task<List<T>> TGetAllAsync(Expression<Func<T, bool>> exp = null);
        Task<T> TGetByIdAsync(int id);
        Task<T> TGetByWhereAsync(Expression<Func<T, bool>> exp);
        Task<bool> TAnyAsync(Expression<Func<T, bool>> exp);
        Task<bool> TSaveAsync();
    }
}
