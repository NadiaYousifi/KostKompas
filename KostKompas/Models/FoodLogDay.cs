namespace KostKompas.Models
{
    public class FoodLogDay
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Meal> Meals { get; set; }
        public double KcalGoal { get; set; } = 1800;
        public double ProteinGoal { get; set; } = 160;
        public double CarbohydrateGoal { get; set; } = 150;
        public double FatGoal { get; set; } = 50;
        public double FibreGoal { get; set; } = 35;

        public FoodLogDay(DateTime date)
        {
            Date = date;
            Meals = new List<Meal>
            {
                new Meal(1, "Morgenmad"){ Foods = {new Food(1,"Tomat", 20, 0.7,0,3.3,1.4)} },
                new Meal(2, "Formiddag"),
                new Meal(3, "Frokost"),
                new Meal(4, "Eftermiddag"),
                new Meal(5, "Aftensmad"),
                new Meal(6, "Sen Aften"),
            };
        }

        public FoodLogDay()
        {
            Date = DateTime.Now;
            Meals = new List<Meal>() 
            {
                new(1,"Morgenmad"), 
                new(2,"Frokost"), 
                new(3,"Aftensmad"),
                new(4,"Mellemmåltid"),
            };
        }
        public double TotalKcal
        {
            get { return Meals.Sum(f => f.TotalKcal); }
        }
        public double TotalProtein
        {
            get { return Meals.Sum(f =>f.TotalProtein); }
        }
        public double TotalCarbohydrate
        {
            get { return Meals.Sum(f => f.TotalCarbohydrate);}
        }
        public double TotalFat
        {
            get { return Meals.Sum(f => f.TotalFat); }
        }
        public double TotalFibre
        {
            get { return Meals.Sum(f => f.TotalFibre);}
        }
        public double KcalLeft
        {
            get { return KcalGoal - TotalKcal; }
        }
    }
}
