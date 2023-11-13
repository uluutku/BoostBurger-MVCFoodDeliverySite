using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Helper
{
    public static class BeverageData
    {

        static BeverageData()
        {
            Beverages = new List<Beverage>();
        }

        public static List<Beverage> Beverages{ get; set; }

    }
}
