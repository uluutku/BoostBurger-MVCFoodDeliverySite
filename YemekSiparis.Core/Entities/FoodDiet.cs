namespace YemekSiparis.Core.Entities
{
    public class FoodDiet
    {
        public int FoodID { get; set; }
        public int DietID { get; set; }
        public Food Food { get; set; }
        public Diet Diet { get; set; }

    }
}
