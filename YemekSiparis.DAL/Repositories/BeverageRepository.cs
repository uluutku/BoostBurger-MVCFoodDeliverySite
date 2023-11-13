using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Context;

namespace YemekSiparis.DAL.Repositories
{
    public class BeverageRepository : BaseRepository<Beverage>, IBeverageRepository
    {
        private readonly AppDbContext _context;

        public BeverageRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public  async Task<List<Beverage>> AllIncludeBeverage(params Expression<Func<Beverage, object>>[] include)
        {
            IQueryable<Beverage> query = _context.Beverages.AsQueryable();

            if (include.Any())
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }

            }

            return await query.ToListAsync();
        }
    }
}
