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
    public class OrderDetailBeverageRepository : IOrderDetailBeverageRepository
    {
        private readonly AppDbContext _context;

        public OrderDetailBeverageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(OrderDetailBeverage orderDetail)
        {
            _context.OrderDetailBeverages.Add(orderDetail);
            
            return  await _context.SaveChangesAsync() > 0 ;
        }
    }
}
