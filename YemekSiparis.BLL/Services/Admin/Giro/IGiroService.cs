using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;

namespace YemekSiparis.BLL.Services.Admin.Giro
{
    public interface IGiroService
    {
        Task<GiroListDTO> GetAll();
    }
}
