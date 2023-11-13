using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.Core.Entities
{
    public class Employee : BaseEntity
    {

        public string Name { get; set; }

        public decimal Salary { get; set; } 
        public string Shift { get; set; }   
        public string Role { get; set; }    
        public string Address { get; set; } 

    }
}
