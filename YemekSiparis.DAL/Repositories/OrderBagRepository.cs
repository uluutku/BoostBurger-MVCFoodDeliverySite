using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Context;

namespace YemekSiparis.DAL.Repositories
{
    public class OrderBagRepository : BaseRepository<OrderBag>, IOrderBagRepository
    {
        private readonly AppDbContext _context;

        public OrderBagRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<OrderBag>> AllIncludeOrderBag(params Expression<Func<OrderBag, object>>[] include)
        {
            IQueryable<OrderBag> query = _context.OrderBags.AsQueryable();

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
