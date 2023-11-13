namespace YemekSiparis.Core.Entities
{
    public class OrderDetailBeverage
    {
        public int OrderDetailID { get; set; }
        public int BeverageID { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public Beverage Beverage { get; set; }

    }
}
