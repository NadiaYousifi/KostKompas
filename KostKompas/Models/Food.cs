using System.ComponentModel.DataAnnotations;
namespace KostKompas.Models;
using System.ComponentModel.DataAnnotations.Schema;

    public class Food
    {
        // properties 
        [Key]
        public int Id { get; set; }
        public int User_id { get; set; } // fordi det skal passe til Er-diagrammet
        [ForeignKey("User_id")]
        public User user { get; set; } // fordi noget med databasen 

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public double Kcal { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbohydrate  { get; set; }
        public double Fibre { get; set; }

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
            return $"Name: {Name}, Kcal {Kcal}, Protein: {Protein}, Fat: {Fat}, CarboHydrate: {Carbohydrate}, Fibre: {Fibre}, WeightInGrams: {WeightInGrams}";
        }  
        

   }
