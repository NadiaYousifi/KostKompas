namespace KostKompas.Models
{
    public class Food
    {
        // properties 
        public string Name { get; set; }
        public double Kcal {  get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbohydrate  { get; set; }
        public double Fibre { get; set; }
        public int Id { get; set; }
        public double WeightInGrams { get; set; } = 100;

        // constructor 
        public Food(int id,string name, double kcal, double protein, double fat, double carbohydrate, double fibre)
        {
            Id = id;
            Name = name;
            Kcal = kcal;
            Protein = protein;
            Fat = fat;
            Carbohydrate = carbohydrate;
            Fibre = fibre;
           
        }


        //default constructor 
        public Food()
        {

        }

        // method
        public override string ToString()
        {
            return $"{Name}, name: {Kcal}, kcal: {Protein}, protein: {Carbohydrate}, carbohydrate: {Fibre}, fibre: { WeightInGrams}, weightInGrams;"
            ;
        }  
        

    }
}
