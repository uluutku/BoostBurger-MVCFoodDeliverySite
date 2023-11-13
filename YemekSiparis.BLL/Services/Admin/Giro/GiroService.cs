using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Repositories;

namespace YemekSiparis.BLL.Services.Admin.Giro
{
    public class GiroService : IGiroService
    {
        private readonly IBaseRepository<OrderBag> orderBagRepository;
        private readonly IBaseRepository<Core.Entities.Employee> employeeRepository;
        private readonly ICategoryRepository categoryRepository;

        public GiroService(IBaseRepository<OrderBag> orderBagRepository, IBaseRepository<Core.Entities.Employee> employeeRepository, IBaseRepository<Food> foodRepository, ICategoryRepository categoryRepository)
        {
            this.orderBagRepository = orderBagRepository;
            this.employeeRepository = employeeRepository;
            this.categoryRepository = categoryRepository;
        }
        public async Task<GiroListDTO> GetAll()
        {
            GiroListDTO giroListDTO = new GiroListDTO()
            {
                Employees = await employeeRepository.GetAllAsync(x => x.Status != Core.Enums.Status.Passive),
                OrderBags = await orderBagRepository.GetAllAsync(x => x.Status != Core.Enums.Status.Passive),
                Categories = await categoryRepository.AllIncludeCategory()
            };
            return giroListDTO;
        }
    }
}
