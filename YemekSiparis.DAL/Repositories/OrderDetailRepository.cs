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
    public class OrderDetailRepository : BaseRepository<OrderDetail> , IOrderDetailRepository
    {
        private readonly AppDbContext _context;

        public OrderDetailRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
       
        public async Task<List<OrderDetail>> AllIncludeOrderDetail(Expression<Func<OrderDetail,bool>> express = null,params Expression<Func<OrderDetail, object>>[] include)
        {
            
            IQueryable<OrderDetail> query = _context.OrderDetails.AsQueryable();
            if(express != null)
            {

                query = query.Where(express);

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
    }
}
