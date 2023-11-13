using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Services.Admin.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Core.Entities.Category> categoryRepository;

        public CategoryService(IBaseRepository<Core.Entities.Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<bool> AddCategory(string name)
        {
            Core.Entities.Category category = new Core.Entities.Category()
            { 
                Name = name,
            };
            return await categoryRepository.AddAsync(category);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            Core.Entities.Category category = await categoryRepository.GetByIdAsync(id);
            return await categoryRepository.DeleteAsync(category);
        }

        public async Task<List<Core.Entities.Category>> getAllCategories()
        {
            return await categoryRepository.GetAllAsync(x=>x.Status != Status.Passive);
        }

        public async Task<bool> UpdateCategory(int id, string name)
        {
            Core.Entities.Category category = await categoryRepository.GetByIdAsync(id);
            category.Name = name;
            return await categoryRepository.UpdateAsync(category);
        }
    }
}
