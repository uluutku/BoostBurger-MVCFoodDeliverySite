using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Models.DTOs
{
    public class FoodListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public string Price { get; set; }
        public int PrepTime { get; set; }
        public string CategoryName { get; set; }
    }
}
