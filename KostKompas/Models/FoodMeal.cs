namespace KostKompas.Models
{
    public class FoodMeal
    {
        public int Id { get; set; }

        public int FoodId { get; set; }

        public int MealId { get; set; }

        public double WeightInGrams { get; set; } = 100;

        public Food Food { get; set; }

        public FoodMeal()
        {
            
        }

    }
}
