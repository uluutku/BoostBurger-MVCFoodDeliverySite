using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Services.Admin.Category
{
    public interface ICategoryService
    {
        Task<List<Core.Entities.Category>> getAllCategories();
        Task<bool> AddCategory(string name);
        Task<bool> UpdateCategory(int id, string name);
        Task<bool> DeleteCategory(int id);
    }
}
