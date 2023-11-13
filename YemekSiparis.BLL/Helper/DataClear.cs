using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.BLL.Helper
{
    public static class DataClear
    {


        public static void Clear()
        {
            ExtraData.Extras.Clear();
            BeverageData.Beverages.Clear();

        }
    }
}
