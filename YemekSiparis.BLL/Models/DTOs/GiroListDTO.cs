using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Models.DTOs
{
    public class GiroListDTO
    {
        public List<Employee> Employees { get; set; }
        public List<OrderBag> OrderBags { get; set; }
        public List<Category> Categories { get; set; }
    }
}
