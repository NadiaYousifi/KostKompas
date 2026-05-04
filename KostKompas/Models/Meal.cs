namespace KostKompas.Models
{
    public class Meal
    {
        public int Id { get; set; }
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
