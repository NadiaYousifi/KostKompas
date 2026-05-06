using System.ComponentModel.DataAnnotations;

namespace KostKompas.Models
{
    public class FoodLogDay
    {
        // properties
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Der skal angives et id")]
        public int UserId { get; set; }
        public User User { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }

        [Required(ErrorMessage = "Der skal angives en dato")]
        public DateTime Date { get; set; }

        public List<Meal> Meals { get; set; }

       

        // default constructor
        public FoodLogDay()
        {
            Date = DateTime.Today;

            Meals = new List<Meal>
            {
                new Meal(1, "Morgenmad"),
                new Meal(2, "Formiddag"),
                new Meal(3, "Frokost"),
                new Meal(4, "Eftermiddag"),
                new Meal(5, "Aftensmad"),
                new Meal(6, "Sen Aften"),
            };
        }

        public double TotalKcal
        {
            get { return Meals.Sum(m => m.TotalKcal); }
        }

        public double TotalProtein
        {
            get { return Meals.Sum(m => m.TotalProtein); }
        }

        public double TotalCarbohydrate
        {
            get { return Meals.Sum(m => m.TotalCarbohydrate); }
        }

        public double TotalFat
        {
            get { return Meals.Sum(m => m.TotalFat); }
        }

        public double TotalFibre
        {
            get { return Meals.Sum(m => m.TotalFibre); }
        }


        // tilbage af mål
        //public double KcalLeft
        //{
        //    get { return KcalGoal - TotalKcal; }
        //}
    }
}

