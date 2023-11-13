using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;

namespace YemekSiparis.BLL.Models.ViewModels
{
    public class ListFoodVM
    {

        public List<Food> Foods { get; set; }
    }
}
