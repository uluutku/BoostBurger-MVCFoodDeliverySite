using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparis.Core.Enums
{
    public enum FoodSize
    {
        [Display(Description ="Küçük")]
        Small , 
        [Display(Description ="Orta")]
        
        Medium,
        [Display(Description ="Büyük")]

        Large
    }
}
