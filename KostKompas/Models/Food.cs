using System.ComponentModel.DataAnnotations;

namespace KostKompas.Models
{
    public class Food
    {
        
        public int Id { get; set; }
        [Key]
        [Required(ErrorMessage = "Der skal angives et Id")]
        public int UserId { get; set; }

        public User User { get; set; }
        [Required(ErrorMessage = "Der skal angives et navn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Der skal angives kcal")]
        public double Kcal { get; set; }
        [Required(ErrorMessage = "Der skal angives protein")]
        public double Protein { get; set; }
        [Required(ErrorMessage = "Der skal angives fedt")]
        public double Fat { get; set; }
        [Required(ErrorMessage = "Der skal angives kulhydrater")]
        public double Carbohydrate  { get; set; }
        [Required(ErrorMessage = "Der skal angives fibre")]
        public double Fibre { get; set; }

        public double WeightInGrams { get; set; } = 100;

        // constructor 
        public Food(int id, string name, double kcal, double protein, double fat, double carbohydrate, double fibre)
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
}
