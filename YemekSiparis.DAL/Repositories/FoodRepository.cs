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
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {
        private readonly AppDbContext _context;

        public FoodRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Food>> AllIncludeFood(Expression<Func<Food, bool>>? exp , params Expression<Func<Food, object>>[] include)
        {
            IQueryable<Food> query = _context.Foods.AsQueryable();

            if(exp != null ) 
            {
                query = query.Where(exp);            
            }

            if (include.Any())
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }

            }

            return await query.ToListAsync();
        }

        public async Task<Food> GetByAllInclude(Expression<Func<Food, bool>> exp)
        {
         
            return await _context.Foods.Where(exp).Include(x=>x.Diets).Include(x=>x.Category).FirstOrDefaultAsync();

        }

        public async Task<Food> GetByIncludeFood(Expression<Func<Food, bool>> exp , params Expression<Func<Food, object>>[] include)
        {
            IQueryable<Food> query = _context.Foods.AsQueryable();

            if (exp != null)
            {
                query = query.Where(exp);
            }

            if (include.Any())
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }

            }

            return await query.FirstOrDefaultAsync();

        }
    }
}
