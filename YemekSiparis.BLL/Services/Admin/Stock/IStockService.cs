using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.DTOs;

namespace YemekSiparis.BLL.Services.Admin.Stock
{
    public interface IStockService
    {
        Task<StockListDTO> GetStockList();
        Task<bool> UpdateFoodStock(int id, int Stock);
        Task<bool> UpdateBeverageStock(int id, int Stock);
        Task<bool> UpdateExtraStock(int id, int Stock);
    }
}
