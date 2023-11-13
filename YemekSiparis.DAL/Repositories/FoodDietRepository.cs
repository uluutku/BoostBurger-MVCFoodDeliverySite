using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Context;

namespace YemekSiparis.DAL.Repositories
{
    public class FoodDietRepository : IFoodDietRepository
    {
        private readonly AppDbContext _context;

        public FoodDietRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(FoodDiet entity)
        {
            bool IsExist = _context.FoodDiets.Any(x=> x.FoodID == entity.FoodID && x.DietID == entity.DietID);
            if (!IsExist)
            {
                await _context.FoodDiets.AddAsync(entity);
                return await SaveAsync();
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> DeleteAsync(FoodDiet entity)
        {

            bool IsExist = _context.FoodDiets.Any(x=> x.FoodID == entity.FoodID && x.DietID == entity.DietID);
            if (IsExist)
            {
                _context.FoodDiets.Remove(entity);
                return await SaveAsync();
            }
            else
            {
                return false;
            }

        }

        public async Task<List<FoodDiet>> GetAllAsync(Expression<Func<FoodDiet, bool>> exp = null)
        {
            if (exp == null)
                return await _context.FoodDiets.ToListAsync();
            else
                return await _context.FoodDiets.Where(exp).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
