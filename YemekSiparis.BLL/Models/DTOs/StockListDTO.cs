using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Models.DTOs
{
    public class StockListDTO
    {
        public List<StockProductsDTO> Foods { get; set; }
        public List<StockProductsDTO> Extras { get; set; }
        public List<StockProductsDTO> Beverages { get; set; }
    }
}
