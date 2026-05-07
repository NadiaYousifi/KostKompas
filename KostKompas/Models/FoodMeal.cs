namespace KostKompas.Models
{
    public class FoodMeal
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int MealId { get; set; }
        public double WeightInGrams { get; set; }

        public FoodMeal() { }
    }
}
