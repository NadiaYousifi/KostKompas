namespace KostKompas.Models
{
    public class FoodLogDay
    {
        // properties
        public DateTime Date { get; set; }
        public int Id { get; set; } = -1;

        public List<Meal> Meals { get; set; }

        public double KcalGoal { get; set; } = 1800;

        public double ProteinGoal { get; set; } = 160;
        public double CarbohydrateGoal { get; set; } = 150;
        public double FatGoal { get; set; } = 50;

        public double FibreGoal { get; set; } = 35;

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
        public FoodLogDay(DateTime date)
        {
            Date = date;

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
        public double KcalLeft
        {
            get { return KcalGoal - TotalKcal; }
        }
    }
}

