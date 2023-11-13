using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.Core.Entities
{
    public class Beverage : BaseEntity
    {
        public string Name { get; set; }

        public Beverage()
        {
            OrderDetails = new List<OrderDetailBeverage>();
        }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public bool IsSelected { get; set; }
        public List<OrderDetailBeverage> OrderDetails { get; set; }


    }
}
