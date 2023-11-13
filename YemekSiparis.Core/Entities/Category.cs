using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public Category()
        {
            Foods = new List<Food>();
        }
        public List<Food> Foods { get; set; }

    }
}
