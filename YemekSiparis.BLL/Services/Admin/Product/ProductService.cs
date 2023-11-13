using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Context;
using YemekSiparis.DAL.Repositories;

namespace YemekSiparis.BLL.Services.Admin.Product
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Food> foodRepository;
        private readonly IBaseRepository<Core.Entities.Category> categoryRepository;
        private readonly IBaseRepository<Diet> dietRepository;
        private readonly IFoodDietRepository foodDietRepository;
        private readonly IMapper mapper;

        public ProductService(IBaseRepository<Food> foodRepository, IBaseRepository<Core.Entities.Category> categoryRepository, IBaseRepository<Diet> dietRepository, IFoodDietRepository foodDietRepository, IMapper mapper)
        {
            this.foodRepository = foodRepository;
            this.categoryRepository = categoryRepository;
            this.dietRepository = dietRepository;
            this.foodDietRepository = foodDietRepository;
            this.mapper = mapper;
        }
        public async Task<List<FoodListDTO>> GetFoodList()
        {
            List<Food> foods = await foodRepository.GetAllAsync(x => x.Status != Status.Passive);
            List<FoodListDTO> foodLists = new();
            foreach (Food food in foods)
            {
                FoodListDTO foodListDTO = mapper.Map<FoodListDTO>(food);
                Core.Entities.Category category = await categoryRepository.GetByIdAsync(food.CategoryID);
                foodListDTO.CategoryName = category.Name;
                foodLists.Add(foodListDTO);
            }
            return foodLists;
        }

        public async Task<List<Core.Entities.Category>> GetCategories()
        {
            return await categoryRepository.GetAllAsync();
        }

        public async Task<List<DietListDTO>> GetDiets()
        {
            List<Diet> diets = await dietRepository.GetAllAsync(x => x.Status != Status.Passive);
            List<DietListDTO> dietList = new();
            foreach (Diet item in diets)
            {
                DietListDTO dietListDTO = mapper.Map<DietListDTO>(item);
                dietListDTO.IsChecked = false;
                dietList.Add(dietListDTO);
            }

            return dietList;
        }

        public async Task<bool> CreateFood(ProductCreateDTO productCreateDTO)
        {
            byte[] imageData = null;
            if (productCreateDTO.Image != null && productCreateDTO.Image.Length > 0)
            {
                using (var binaryReader = new BinaryReader(productCreateDTO.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)productCreateDTO.Image.Length);
                }
            }

            Food food = new();
            food.Name = productCreateDTO.Name;
            food.Stock = productCreateDTO.Stock;
            food.Description = productCreateDTO.Description;
            food.PrepTime = productCreateDTO.PrepTime;
            food.Price = productCreateDTO.Price;
            food.Discount = productCreateDTO.Discount;
            food.CategoryID = productCreateDTO.CategoryID;
            food.Image = imageData;

            await foodRepository.AddAsync(food);
            FoodDiet foodDiet = new();
            bool result = true;
            foreach (DietListDTO item in productCreateDTO.Diets)
            {
                if (item.IsChecked)
                {
                    Diet diet = mapper.Map<Diet>(item);
                    foodDiet.DietID = diet.Id;
                    foodDiet.FoodID = food.Id;
                    result = await foodDietRepository.AddAsync(foodDiet);

                }
            }

            return result;
        }

        public async Task<ProductUpdateDTO> GetUpdateFood(int id)
        {
            Food food = await foodRepository.GetByIdAsync(id);
            ProductUpdateDTO productUpdateDTO = mapper.Map<ProductUpdateDTO>(food);
            List<Diet> diets = await dietRepository.GetAllAsync();
            List<FoodDiet> foodDiets = await foodDietRepository.GetAllAsync(x => x.FoodID == food.Id);
            foreach (Diet item in diets)
            {
                DietListDTO dietListDTO = mapper.Map<DietListDTO>(item);
                if (foodDiets.Any(x => x.DietID == item.Id))
                {
                    dietListDTO.IsChecked = true;
                }
                else
                {
                    dietListDTO.IsChecked = false;
                }

                productUpdateDTO.Diets.Add(dietListDTO);
            }

            return productUpdateDTO;
        }

        public async Task<bool> PostUpdateFood(ProductUpdateDTO productUpdateDTO)
        {
            Food food = await foodRepository.GetByIdAsync(productUpdateDTO.Id);
            food.Id = productUpdateDTO.Id;
            food.Name = productUpdateDTO.Name;
            food.Stock = productUpdateDTO.Stock;
            food.Description = productUpdateDTO.Description;
            food.PrepTime = productUpdateDTO.PrepTime;
            food.Price = productUpdateDTO.Price;
            food.Discount = productUpdateDTO.Discount;
            food.CategoryID = productUpdateDTO.CategoryID;

            if (productUpdateDTO.Image != null && productUpdateDTO.Image.Length > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(productUpdateDTO.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)productUpdateDTO.Image.Length);
                }
                food.Image = imageData;
            }

            await foodRepository.UpdateAsync(food);
            FoodDiet foodDiet = new();
            bool result = true;
            foreach (DietListDTO item in productUpdateDTO.Diets)
            {
                Diet diet = mapper.Map<Diet>(item);
                foodDiet.DietID = diet.Id;
                foodDiet.FoodID = food.Id;
                if (item.IsChecked)
                {
                    result = await foodDietRepository.AddAsync(foodDiet);
                }
                else
                {
                    result = await foodDietRepository.DeleteAsync(foodDiet);
                }
            }

            return result;
        }

        public Task<bool> DeleteFood(int id)
        {
            return foodRepository.DeleteAsync(id);
        }
    }
}
