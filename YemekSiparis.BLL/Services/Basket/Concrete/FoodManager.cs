using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Context;
using YemekSiparis.DAL.Repositories;

namespace YemekSiparis.BLL.Services.Basket.Concrete
{
    public class FoodManager : BaseManager<Food>, IFoodService
    {
        private readonly IBaseRepository<Food> _baseRepository;
        private readonly AppDbContext _dbContext;

        public FoodManager(IBaseRepository<Food> baseRepository, AppDbContext dbContext) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _dbContext = dbContext;
        }

        public async Task<bool> DefaultUpdate(Food food)
        {
           
            if(food == null)
            {
                return false;
            }

            _dbContext.Foods.Update(food);
          return   await _dbContext.SaveChangesAsync() >0;

        }
    }
}
