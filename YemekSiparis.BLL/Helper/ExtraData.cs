using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Helper
{
    public static class ExtraData
    {
         static ExtraData()
        {
            Extras = new List<Extra>();

        }

        public static List<Extra> Extras { get; set; }
    }
}
