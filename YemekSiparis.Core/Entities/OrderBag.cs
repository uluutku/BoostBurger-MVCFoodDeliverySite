using YemekSiparis.Core.Enums;

namespace YemekSiparis.Core.Entities
{
    public class OrderBag : BaseEntity
    {
        public OrderBag()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public DateTime OrderDate { get; set; } 
        public decimal? TotalPrice { get; set; }    
        public List<OrderDetail> OrderDetails { get; set; } 
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
