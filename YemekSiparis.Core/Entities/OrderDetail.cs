using YemekSiparis.Core.Enums;

namespace YemekSiparis.Core.Entities
{
    public class OrderDetail : BaseEntity
    {
        public OrderDetail()
        {
            Extras = new List<OrderDetailExtra>();

            Beverages = new List<OrderDetailBeverage>();
        }

        public decimal UnitPrice { get; set; }   
        public int Quantity { get; set; }        
        public int? FoodID { get; set; }          
        public int? OrderBagID { get; set; }         
        public List<OrderDetailExtra> Extras { get; set; }  
        public List<OrderDetailBeverage> Beverages { get; set; }
        public Food? Food { get; set; }
        public OrderBag? OrderBag { get; set; }
        public FoodSize FoodSize{ get; set; }

    }
}
