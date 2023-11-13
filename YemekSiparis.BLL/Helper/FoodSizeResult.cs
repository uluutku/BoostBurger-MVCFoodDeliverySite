using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Enums;

namespace YemekSiparis.BLL.Helper
{
    public static class FoodSizeResult
    {
        public static decimal SizePrice(FoodSize foodSize)
        {
            decimal price = 1;

            switch (foodSize)
            {
                case FoodSize.Small:
                    price = 1;
                    break;
                case FoodSize.Medium:
                    price = 1.15m;
                    break;
                case FoodSize.Large:
                    price = 1.25m;
                    break;                  
            }

            return price;
         }

    }
}
