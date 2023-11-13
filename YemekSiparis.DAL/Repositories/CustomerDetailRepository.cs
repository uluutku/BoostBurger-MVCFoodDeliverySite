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
    public class CustomerDetailRepository : BaseRepository<Customer>, ICustomerDetailRepository
    {
        private readonly AppDbContext _context;

        public CustomerDetailRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        Task<List<Customer>> ICustomerDetailRepository.AllIncludeFood()
        {
            return _context.Customers.Include(x=> x.Orders).ThenInclude(x=> x.OrderDetails).ThenInclude(x=> x.Food).ToListAsync();
        }
    }
}
