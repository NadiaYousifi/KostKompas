namespace KostKompas.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Kcal { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double CarboHydrate { get; set; }
        public double Fibre { get; set; }

        public double WeightInGrams { get; set; } = 100;


        public Food(int id,string name, double kcal, double protein, double fat, double carboHydrate, double fibre)
        {
            Id = id;
            Name = name;
            Kcal = kcal;
            Protein = protein;
            Fat = fat;
            CarboHydrate = carboHydrate;
            Fibre = fibre;
            
           
        }

        public Food()
        {

        }

        public override string ToString()
        {
            return $"Name: {Name}, Kcal {Kcal}, Protein: {Protein}, Fat: {Fat}, CarboHydrate: {CarboHydrate}, Fibre: {Fibre}, WeightInGrams: {WeightInGrams}";
        }
    }
}
