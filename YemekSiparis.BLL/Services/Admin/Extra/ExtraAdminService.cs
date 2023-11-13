using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.Core.Enums;
using YemekSiparis.Core.IRepositories;

namespace YemekSiparis.BLL.Services.Admin.Extra
{
    public class ExtraAdminService : IExtraAdminService
    {
        private readonly IBaseRepository<Core.Entities.Extra> extraRepository;
        private readonly IMapper mapper;

        public ExtraAdminService(IBaseRepository<Core.Entities.Extra> extraRepository, IMapper mapper)
        {
            this.extraRepository = extraRepository;
            this.mapper = mapper;
        }

        public Task<bool> AddExtra(ExtraCreateDTO extraCreateDTO)
        {
            Core.Entities.Extra extra = mapper.Map<Core.Entities.Extra>(extraCreateDTO);
            return extraRepository.AddAsync(extra);
        }

        public async Task<bool> DeleteExtra(int id)
        {
            Core.Entities.Extra extra = await extraRepository.GetByIdAsync(id);
            if (extra == null)
            {
                return false;
            }
            return await extraRepository.DeleteAsync(extra);
        }

        public async Task<ExtraUpdateDTO> getExtra(int id)
        {
            Core.Entities.Extra extra = await extraRepository.GetByIdAsync(id);
            if(extra == null) {
                return null;
            }
            ExtraUpdateDTO extraUpdateDTO = mapper.Map<ExtraUpdateDTO>(extra);
            return extraUpdateDTO;
        }

        public async Task<List<ExtraListDTO>> GetExtras()
        {
            List<Core.Entities.Extra> extraListDTOs = await extraRepository.GetAllAsync(x => x.Status != Status.Passive);
            List<ExtraListDTO> extraLists = new();
            foreach (Core.Entities.Extra item in extraListDTOs)
            {
                ExtraListDTO extraListDTO = mapper.Map<ExtraListDTO>(item);
                extraLists.Add(extraListDTO);
            }
            return extraLists;
        }

        public Task<bool> UpdateExtra(ExtraUpdateDTO extraUpdate)
        {
            Core.Entities.Extra extra = mapper.Map<Core.Entities.Extra>(extraUpdate);
            return extraRepository.UpdateAsync(extra);
        }
    }
}
