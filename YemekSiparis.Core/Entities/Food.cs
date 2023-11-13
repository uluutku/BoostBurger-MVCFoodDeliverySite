using YemekSiparis.Core.Enums;

namespace YemekSiparis.Core.Entities
{
    public class Food : BaseEntity
    {
        public string Name { get; set; }

        public Food()
        {
            Diets = new List<FoodDiet>();
            OrderDetails = new List<OrderDetail>();
        }        
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Rating { get; set; } 
        public int ClickCount { get; set; } = 0;
        public byte[]? Image { get; set; }
        public int PrepTime { get; set; }
        public decimal Discount { get; set; } = 0;
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<FoodDiet> Diets { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } 
    }

}

