using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.BLL.Services.Admin.Bevarage;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;
using YemekSiparis.Core.IRepositories;
using YemekSiparis.DAL.Repositories;

namespace YemekSiparis.BLL.Services.Admin.Beverage
{
    public class BeverageAdminService : IBeverageAdminService
    {
        private readonly IBaseRepository<Core.Entities.Beverage> beverageRepository;
        private readonly IMapper mapper;

        public BeverageAdminService(IBaseRepository<Core.Entities.Beverage> beverageRepository, IMapper mapper)
        {
            this.beverageRepository = beverageRepository;
            this.mapper = mapper;
        }
        public Task<bool> AddExtra(BeverageCreateDTO beverageCreateDTO)
        {
            Core.Entities.Beverage beverage = mapper.Map<Core.Entities.Beverage>(beverageCreateDTO);
            return beverageRepository.AddAsync(beverage);
        }

        public async Task<bool> DeleteExtra(int id)
        {
            Core.Entities.Beverage beverage = await beverageRepository.GetByIdAsync(id);
            if (beverage == null)
            {
                return false;
            }
            return await beverageRepository.DeleteAsync(beverage);
        }

        public async Task<BeverageUpdateDTO> getExtra(int id)
        {
            Core.Entities.Beverage beverage = await beverageRepository.GetByIdAsync(id);
            if (beverage == null)
            {
                return null;
            }
            BeverageUpdateDTO beverageUpdate = mapper.Map<BeverageUpdateDTO>(beverage);
            return beverageUpdate;
        }

        public async Task<List<BeverageListDTO>> GetExtras()
        {
            List<Core.Entities.Beverage> beverages = await beverageRepository.GetAllAsync(x => x.Status != Status.Passive);
            List<BeverageListDTO> beverageListDTOs = new();
            foreach (Core.Entities.Beverage item in beverages)
            {
                BeverageListDTO beverageListDTO = mapper.Map<BeverageListDTO>(item);
                beverageListDTOs.Add(beverageListDTO);
            }
            return beverageListDTOs;
        }

        public Task<bool> UpdateExtra(BeverageUpdateDTO beverageUpdateDTO)
        {
            Core.Entities.Beverage beverage = mapper.Map<Core.Entities.Beverage>(beverageUpdateDTO);
            return beverageRepository.UpdateAsync(beverage);
        }
    }
}
