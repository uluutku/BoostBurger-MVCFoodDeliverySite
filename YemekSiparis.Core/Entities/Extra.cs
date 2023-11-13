using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.Core.Entities
{
    public class Extra : BaseEntity
    {
        public string Name { get; set; }
        public Extra()
        {
            OrderDetails = new List<OrderDetailExtra>();
        }
        public int Stock { get; set; }   
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
        public List<OrderDetailExtra> OrderDetails { get; set; } 
    }
}
