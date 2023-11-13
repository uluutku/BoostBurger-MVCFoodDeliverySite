using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;

namespace YemekSiparis.BLL.Services.Admin.Bevarage
{
    public interface IBeverageAdminService
    {
        Task<List<BeverageListDTO>> GetExtras();
        Task<bool> AddExtra(BeverageCreateDTO extra);
        Task<BeverageUpdateDTO> getExtra(int id);
        Task<bool> UpdateExtra(BeverageUpdateDTO extraUpdateDTO);
        Task<bool> DeleteExtra(int id);
    }
}
