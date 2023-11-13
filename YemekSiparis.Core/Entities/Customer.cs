using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Enums;

namespace YemekSiparis.Core.Entities
{
    public class Customer : BaseEntity
    {
     
        public string Name { get; set; }

        public Customer()
        {
            Orders = new List<OrderBag>();
        }

        public int? Age { get; set; }        
        public DateTime? Birthdate { get; set; } 
        public Gender Gender { get; set; }  = Enums.Gender.Erkek;
        public string Address { get; set; } 

        public List<OrderBag> Orders { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
