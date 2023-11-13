using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.BLL.Models.ViewModels;
using YemekSiparis.BLL.Services.Basket.Abstract;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Helper
{
    public static class TotalResult
    {


        public static decimal TotalExtra(List<Extra> extras)
        {
            decimal total = 0;
            foreach (Extra extra in extras) 
            {
                total += extra.Price;            
            }

            return total;

        }

        public static decimal TotalBeverage(List<Beverage> beverages)
        {

            decimal total = 0;

            foreach (Beverage beverage in beverages)
            {
                total += beverage.Price;
            }

            return total;

        }

    }
}
