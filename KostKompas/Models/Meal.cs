namespace KostKompas.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Food> Foods { get; set; }

        public double TotalKcal
        {
            get { return Foods.Sum(f =>((f.WeightInGrams/100) * f.Kcal)); }
        }

        public double TotalProtein
        {
            get { return Foods.Sum(f => ((f.WeightInGrams / 100) * f.Protein)); }
        }

        public double TotalFat
        {
            get { return Foods.Sum(f => ((f.WeightInGrams / 100) * f.Fat)); }
        }

        public double TotalCarboHydrate
        {
            get { return Foods.Sum(f => ((f.WeightInGrams / 100) * f.CarboHydrate)); }
        }

        public double TotalFibre
        {
            get { return Foods.Sum(f => ((f.WeightInGrams / 100) * f.Fibre)); }
        }



        public Meal(int id, string name)
        {
            Id = id;
            Name = name;
            Foods = new List<Food>();
        }

        public Meal()
        {
            Foods = new List<Food>();

        }

    }
}
