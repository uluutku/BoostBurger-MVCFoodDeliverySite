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
    public class ExtraRepository : BaseRepository<Extra>, IExtraRepository
    {
        private readonly AppDbContext _context;

        public ExtraRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Extra>> AllIncludeExtra(params Expression<Func<Extra, object>>[] include)
        {
            IQueryable<Extra> query = _context.Extras.AsQueryable();

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
