using System.ComponentModel.DataAnnotations;

namespace KostKompas.Models
{
    public class Meal
    {
        // Properties
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Der skal angives et navn")]
        public string Name { get; set; }
        [Required]
        public int FoodLogDayId { get; set; }
        public List<FoodMeal> FoodMeals { get; set; }

        public double TotalKcal
        {
            get { return FoodMeals.Sum(f => ((f.WeightInGrams / 100) * f.Food.Kcal)); }
        }

        public double TotalProtein
        {
            get { return FoodMeals.Sum(f => ((f.WeightInGrams / 100) * f.Food.Protein)); }
        }

        public double TotalFat
        {
            get { return FoodMeals.Sum(f => ((f.WeightInGrams / 100) * f.Food.Fat)); }
        }

        public double TotalCarbohydrate
        {
            get { return FoodMeals.Sum(f => ((f.WeightInGrams / 100) * f.Food.Carbohydrate)); }
        }

        public double TotalFibre
        {
            get { return FoodMeals.Sum(f => ((f.WeightInGrams / 100) * f.Food.Fibre)); }
        }


        // Constructors
        public Meal(string name, int foodLogDayId)
        {
            Name = name;
            FoodLogDayId = foodLogDayId;
            FoodMeals = new List<FoodMeal>(); // gemmer listen til constructoren, når der laves et nyt meal
        }

        // default constructor 
        public Meal()
        {
            FoodMeals = new List<FoodMeal>(); // vi har en liste fordi vi gerne vil kunne oprette en ny liste
        }


    }
}



