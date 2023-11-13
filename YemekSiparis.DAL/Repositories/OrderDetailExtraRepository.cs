using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Context;

namespace YemekSiparis.DAL.Repositories
{
    public class OrderDetailExtraRepository : IOrderDetailExtraRepository
    {
        private readonly AppDbContext _context;

        public OrderDetailExtraRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(OrderDetailExtra extra)
        {
            _context.OrderDetailExtras.Add(extra);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
