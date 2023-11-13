using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Services.Admin.Extra
{
    public interface IExtraAdminService
    {
        Task<List<ExtraListDTO>> GetExtras();
        Task<bool> AddExtra(ExtraCreateDTO extra);
        Task<ExtraUpdateDTO> getExtra(int id);
        Task<bool> UpdateExtra(ExtraUpdateDTO extraUpdateDTO);
        Task<bool> DeleteExtra(int id);
    }
}
