using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.ViewModels;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Context;
using YemekSiparis.DAL.Repositories;

namespace YemekSiparis.BLL.Services.Basket.Concrete
{
    public class OrderDetailManager : BaseManager<OrderDetail>, IOrderDetailService
    {
        private readonly IBaseRepository<OrderDetail> _baseRepository;
        private readonly AppDbContext _appContext;

        public OrderDetailManager(IBaseRepository<OrderDetail> baseRepository, AppDbContext appContext) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _appContext = appContext;
        }

        public async Task<List<OrderDetail>> AllIncludeOrderDetail(Expression<Func<OrderDetail, bool>> expression = null, params Expression<Func<OrderDetail, object>>[] include)
        {

            IQueryable<OrderDetail> query = _appContext.OrderDetails.AsQueryable();
            if (expression != null)
            {

                query = query.Where(expression);

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

        public async Task<List<OrderDetail>> AllThenInclude(Expression<Func<OrderDetail, bool>> expression = null)
        {

            IQueryable<OrderDetail> query = _appContext.OrderDetails.AsQueryable();
            if (expression != null)
            {

                query = query.Where(expression);

            }

            return await query.Include(x => x.Extras).ThenInclude(od => od.Extra).Include(x => x.Beverages).ThenInclude(bv => bv.Beverage).Include(x => x.Food).Include(x => x.OrderBag).ToListAsync();

        }

        //public async Task<bool> CreateDetailVM(CreateOrderDetailVM vm)
        //{

        //    //OrderDetail orderDetail = new OrderDetail();
        //    //orderDetail.FoodID = detailVM.FoodId;
        //    //orderDetail.OrderBagID = bag.Id;
        //    //await _orderDetailService.AddAsync(orderDetail);
        //    throw new NotImplementedException();
        //}

        public async Task<bool> DefaultUpdateAsync(OrderDetail orderDetail)
        {
            _appContext.OrderDetails.Update(orderDetail);
            return _appContext.SaveChanges() > 0;
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
