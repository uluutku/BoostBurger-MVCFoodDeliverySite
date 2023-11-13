namespace YemekSiparis.Core.Entities
{
    public class OrderDetailExtra
    {
        public int OrderDetailID { get; set; }
        public int ExtraID { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public Extra Extra { get; set; }
    }

}
