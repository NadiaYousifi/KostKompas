namespace KostKompas.Models
{
    public class FoodLogDay
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public List<Meal> Meals { get; set; }

        public double KcalGoal { get; set; } = 1800;

        public double ProteinGoal { get; set; } = 160;

        public double CarboHydrateGoal { get; set; } = 150;

        public double FatGoal { get; set; } = 50;

        public double FibreGoal { get; set; } = 35;


        public FoodLogDay(int id)
        {
            Id = id;

            Date = DateTime.Today;

            Meals = new List<Meal>
            {
                new Meal(1, "Morgenmad"),
                new Meal(2, "Frokost"),
                new Meal(3, "Aftensmad"),
                new Meal(4, "Mellemmåltid"),

            };
        }

        public double TotalKcal
        {
            get { return Meals.Sum(f => f.TotalKcal); }
        }

        public double TotalProtein
        {
            get { return Meals.Sum(f => f.TotalProtein); }
        }

        public double TotalFat
        {
            get { return Meals.Sum(f => f.TotalFat); }
        }

        public double TotalCarbohydrate
        {
            get { return Meals.Sum(f => f.TotalCarboHydrate); }
        }

        public double TotalFibre
        {
            get { return Meals.Sum(f => f.TotalFibre); }
        }

        public double KcalLeft
        {
            get { return KcalGoal - TotalKcal; }
        }

    }

}
