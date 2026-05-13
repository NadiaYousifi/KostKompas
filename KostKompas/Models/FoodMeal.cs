using System.ComponentModel.DataAnnotations;

namespace KostKompas.Models
{
    public class FoodMeal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int FoodId { get; set; }
        public Food Food { get; set; }
        [Required]
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        [Required]
        public double WeightInGrams { get; set; }

        public FoodMeal() { }
        public FoodMeal(int foodId, int mealId, double weightInGrams) 
        {
            FoodId = foodId;
            MealId = mealId;
            WeightInGrams = weightInGrams;
        }
    }
}
