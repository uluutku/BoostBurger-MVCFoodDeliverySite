using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Services.Basket.Concrete
{
    public class BaseManager<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseManager(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> AddAsync(T entity)
        {
            if (entity != null)
            {
                await _baseRepository.AddAsync(entity);
                return true;
            }
            else
            { return false; }

        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _baseRepository.AnyAsync(exp);
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity != null)
            {
                await _baseRepository.DeleteAsync(entity);
                return true;
            }
            else
            { return false; }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id > 0)
            {
                await _baseRepository.DeleteAsync(id);
                return true;
            }
            else
            { return false; }
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp = null)
        {
            
            return await _baseRepository.GetAllAsync(exp);          
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public async Task<T> GetByWhereAsync(Expression<Func<T, bool>> exp)
        {
            return await _baseRepository.GetByWhereAsync(exp);

        }

        public async Task<bool> HardDeleteAsync(T entity)
        {
            if (entity != null)
            {
                await _baseRepository.HardDeleteAsync(entity);
                return true;
            }
            else
            { return false; }
        }

        public  async Task<bool> HardDeleteAsync(int id)
        {
            if (id > 0)
            {
                await _baseRepository.HardDeleteAsync(id);
                return true;
            }
            else
            { return false; }
        }

        public async Task<bool> UpdateAsync(T entity)
        {

            if (entity != null)
            {
                await _baseRepository.UpdateAsync(entity);
                return true;
            }
            else
            { return false; }

        }
    }
}
