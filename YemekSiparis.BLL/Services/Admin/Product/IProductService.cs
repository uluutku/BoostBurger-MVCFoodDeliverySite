using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Services.Admin.Product
{
    public interface IProductService
    {
        Task<List<FoodListDTO>> GetFoodList();
        Task<List<Core.Entities.Category>> GetCategories();
        Task<List<DietListDTO>> GetDiets();
        Task<bool> CreateFood(ProductCreateDTO productCreateDTO);
        Task<ProductUpdateDTO> GetUpdateFood(int id);
        Task<bool> PostUpdateFood(ProductUpdateDTO productUpdateDTO);
        Task<bool> DeleteFood(int id);
    }
}
