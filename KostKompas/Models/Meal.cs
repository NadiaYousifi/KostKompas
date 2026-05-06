using System.ComponentModel.DataAnnotations;

namespace KostKompas.Models
{



    public class Meal
    {

        // Properties
        public int Id { get; set; }

        [Required(ErrorMessage = "Der skal angives et navn")]
        public string Name { get; set; }

        public List<Food> Foods {get; set; }

        public double TotalKcal
        {
            get { return Foods.Sum(f => ((f.WeightInGrams / 100) * f.Kcal)); }
        }

        public double TotalProtein
        {
            get { return Foods.Sum(f => ((f.WeightInGrams / 100) * f.Protein)); }
        }

        public double TotalFat
        {
            get { return Foods.Sum(f => ((f.WeightInGrams / 100) * f.Fat)); }
        }

        public double TotalCarbohydrate
        {
            get { return Foods.Sum(f => ((f.WeightInGrams / 100) * f.Carbohydrate)); }
        }

        public double TotalFibre
        {
            get { return Foods.Sum(f => ((f.WeightInGrams / 100) * f.Fibre)); }
        }


        // Constructors
        public Meal(int id, string name)
        {
            Id = id;
            Name = name;
            Foods = new List<Food>(); // gemmer listen til constructoren, når der laves et nyt meal
        }

        // default constructor 
        public Meal()
        {
            Foods = new List<Food>(); // vi har en liste fordi vi gerne vil kunne oprette en ny liste
        }


        // Methods
        public void AddFood(Food food)
        {
            Foods.Add(food);
        }

        //public void RemoveFood(Food food)
        //{
        //    Foods.Remove(food);
        //}
    }
}



