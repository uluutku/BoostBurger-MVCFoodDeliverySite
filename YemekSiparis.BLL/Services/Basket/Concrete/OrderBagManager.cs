using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Helper;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Context;
using YemekSiparis.DAL.Repositories;

namespace YemekSiparis.BLL.Services.Basket.Concrete
{
    public class OrderBagManager : BaseManager<OrderBag>, IOrderBagService
    {
        private readonly IBaseRepository<OrderBag> _baseRepository;
        private readonly IBeverageService _beverageService;
        private readonly IExtraService _extraService;
        private readonly AppDbContext _dbContext;

        public OrderBagManager(IBaseRepository<OrderBag> baseRepository, IBeverageService beverageService, IExtraService extraService, AppDbContext dbContext) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _beverageService = beverageService;
            _extraService = extraService;
            _dbContext = dbContext;
        }

        public async Task<bool> DefaultUpdate(OrderBag orderBag)
        {
            if (orderBag == null)
            {
                return false;

            }

            _dbContext.OrderBags.Update(orderBag);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<OrderBag>> GetAllIncludeOrderss(Expression<Func<OrderBag, bool>> expression, params Expression<Func<OrderBag, object>>[] includes)
        {
            IQueryable<OrderBag> query = _dbContext.OrderBags.AsQueryable();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);

                }
            }

            return await query.ToListAsync();

        }

        public async Task<OrderBag> GetOrderBagID(int customerId)
        {
            OrderBag bag = new OrderBag();
            bag.CustomerId = customerId;
            bag.OrderStatus = OrderStatus.InProgress;
            await _baseRepository.AddAsync(bag);
            return bag;

        }

        public async Task<decimal> TotalPayment(List<OrderDetail> orderDetails)
        {
            decimal totalPayment = 0;



            foreach (OrderDetail detail in orderDetails)
            {

                if (detail.Extras.Count <= 0 && detail.Beverages.Count <= 0)
                {
                    totalPayment += Math.Round((detail.Food.Price * (1 - detail.Food.Discount)) * detail.Quantity, 2) * FoodSizeResult.SizePrice(detail.FoodSize);

                }
                else if (detail.Extras.Count > 0 && detail.Beverages.Count <= 0)
                {
                    totalPayment += Math.Round(((detail.Food.Price * (1 - detail.Food.Discount)) * detail.Quantity) * FoodSizeResult.SizePrice(detail.FoodSize) + await _extraService.AdditionAsync(null, detail.Extras), 2);
                }
                else if (detail.Beverages.Count > 0 && detail.Extras.Count <= 0)
                {
                    totalPayment += Math.Round(((detail.Food.Price * (1 - detail.Food.Discount)) * detail.Quantity) * FoodSizeResult.SizePrice(detail.FoodSize) + await _beverageService.AdditionAsync(null, detail.Beverages), 2);
                }
                else
                {
                    totalPayment += Math.Round(((detail.Food.Price * (1 - detail.Food.Discount)) * detail.Quantity) * FoodSizeResult.SizePrice(detail.FoodSize) + await _beverageService.AdditionAsync(null, detail.Beverages) + await _extraService.AdditionAsync(null, detail.Extras), 2);

                }
            }

            return totalPayment;

        }
    }
}
