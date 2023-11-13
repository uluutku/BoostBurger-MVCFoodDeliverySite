using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekSiparis.Core.Entities;
using YemekSiparis.Core.Enums;

namespace YemekSiparis.BLL.Models.ViewModels
{
    public class CreateOrderDetailVM
    {
        public CreateOrderDetailVM()
        {
            Extras = new List<Extra>();
            Beverages = new List<Beverage>();
        }

        public int OrderDetailId { get; set; }
        public FoodSize FoodSize { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.InProgress;
        public int CustomerId { get; set; } = 1;
        public int Quantity { get; set; } = 1;
        public int FoodId { get; set; }
        public Food Food{ get; set; }
        public int ExtraId { get; set; }
        public bool IsSelected { get; set; }
        public List<Extra> Extras { get; set; }
        public int BeverageId { get; set; }
        public List<Beverage> Beverages { get; set; }

    }




}
