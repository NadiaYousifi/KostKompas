using System.ComponentModel.DataAnnotations;

namespace KostKompas.Models
{
    public class Food
    {
        // properties 
        [Key]
        public int Id { get; set; }

        //public int UserId { get; set; }

        public User? User { get; set; }
        [Required(ErrorMessage = "Der skal angives et navn")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Der skal angives Kcal")]

        public double Kcal { get; set; }
        [Required(ErrorMessage = "Der skal angives protein")]

        public double Protein { get; set; }
        [Required(ErrorMessage = "Der skal angives fedt")]
        public double Fat { get; set; }
        [Required(ErrorMessage = "Der skal angives kulhydrater")]
        public double Carbohydrate { get; set; }
        [Required(ErrorMessage = "Der skal angives fibre")]
        public double Fibre { get; set; }



        // constructor 
        public Food(string name, double kcal, double protein, double fat, double carbohydrate, double fibre)
        {
            
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
            return $"Name: {Name}, Kcal {Kcal}, Protein: {Protein}, Fat: {Fat}, CarboHydrate: {Carbohydrate}, Fibre: {Fibre}";
        }

    }
}
