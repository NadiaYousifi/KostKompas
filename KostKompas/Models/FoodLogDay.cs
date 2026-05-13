using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KostKompas.Models
{
    public class FoodLogDay
    {
        // properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = -1;
        [Required(ErrorMessage = "Der skal angives en dato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Der skal angives et Id")]
        public string UserEmail { get; set; }
        public User User { get; set; }
        public List<Meal> Meals { get; set; }

        // default constructor
        public FoodLogDay()
        {
            Date = DateTime.Today;

            Meals = new List<Meal>
            {
                new Meal("Morgenmad", Id),
                new Meal("Formiddag", Id),
                new Meal("Frokost", Id),
                new Meal("Eftermiddag", Id),
                new Meal("Aftensmad", Id),
                new Meal("Sen Aften", Id),
            };
        }
        public FoodLogDay(DateTime date)
        {
            Date = date;

            Meals = new List<Meal>
            {
                new Meal("Morgenmad", Id),
                new Meal("Formiddag", Id),
                new Meal("Frokost", Id),
                new Meal("Eftermiddag", Id),
                new Meal("Aftensmad", Id),
                new Meal("Sen Aften", Id),
            };
        }

        public double TotalKcal
        {
            get {return Meals.Sum(m => m.TotalKcal); }
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

