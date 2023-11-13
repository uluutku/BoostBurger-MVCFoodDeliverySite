using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities.Abstract;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Context;
using YemekSiparis.Core.Enums;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.DAL.Repositories
{

    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.Status = Status.Active;
            await _context.Set<T>().AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().AnyAsync(exp);
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            entity.DeletedDate = DateTime.Now;
            entity.Status = Status.Passive;
            _context.Set<T>().Update(entity);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);

            entity.DeletedDate = DateTime.Now;
            entity.Status = Status.Passive;
            _context.Set<T>().Update(entity);
            return await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? exp = null)
        {
            if (exp == null)
                return await _context.Set<T>().ToListAsync();
            else
                return await _context.Set<T>().Where(exp).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByWhereAsync(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(exp);
        }

        public async Task<bool> HardDeleteAsync(T entity)
        {
            await Task.Run(() => _context.Remove(entity));
            return await SaveAsync();
        }

        public async Task<bool> HardDeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            await Task.Run(() => _context.Set<T>().Remove(entity));
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                Console.Write(ex.ToString());
                return false;   
            }
        
        }

        public async Task<bool> UpdateAsync(T entity)
        {       
            entity.ModifiedDate = DateTime.Now;
            entity.Status = Status.Modified;
            _context.Set<T>().Update(entity);
            return await SaveAsync();
        }
    }
}
