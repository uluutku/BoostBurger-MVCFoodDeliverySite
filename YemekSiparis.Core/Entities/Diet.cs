using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.Core.Entities
{
    public class Diet : BaseEntity
    {
        public string Name { get; set; }

        public Diet()
        {
            Foods = new List<FoodDiet>();
        }
        public string Description { get; set; }

        public List<FoodDiet> Foods { get; set; }


    }
}
