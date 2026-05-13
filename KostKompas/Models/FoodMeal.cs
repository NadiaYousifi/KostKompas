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
        public double TotalKcal
        {
            get { return (WeightInGrams / 100) * Food.Kcal; }
        }

        public double TotalProtein
        {
            get { return (WeightInGrams / 100) * Food.Protein; }
        }

        public double TotalFat
        {
            get { return (WeightInGrams / 100) * Food.Fat; }
        }

        public double TotalCarbohydrate
        {
            get { return (WeightInGrams / 100) * Food.Carbohydrate; }
        }

        public double TotalFibre
        {
            get { return (WeightInGrams / 100) * Food.Fibre; }
        }

        public FoodMeal() { }
        public FoodMeal(int foodId, int mealId, double weightInGrams) 
        {
            FoodId = foodId;
            MealId = mealId;
            WeightInGrams = weightInGrams;
        }
    }
}
