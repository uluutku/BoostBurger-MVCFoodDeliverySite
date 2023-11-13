using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.Core.IRepositories
{
    public interface IFoodDietRepository
    {
        Task<bool> AddAsync(FoodDiet entity);
        Task<bool> DeleteAsync(FoodDiet entity);
        Task<List<FoodDiet>> GetAllAsync(Expression<Func<FoodDiet, bool>> exp = null);
        Task<bool> SaveAsync();

    }
}
