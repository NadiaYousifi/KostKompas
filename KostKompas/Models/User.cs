using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KostKompas.Models
{
    public class User
    {

        // instance fields
        // konstanter 
        public const double MaleBaseConstant = 66.5;

        public const double MaleWeightConstant = 13.75;

        public const double MaleHeightConstant = 5.003;

        public const double MaleAgeConstant = 6.755;

        public const double FemaleBaseConstant = 655;

        public const double FemaleWeightConstant = 9.563;

        public const double FemaleHeightConstant = 1.850;

        public const double FemaleAgeConstant = 4.676;

        // properties 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Der skal angives et navn")]
        public string Name { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Der skal angives en password")]
        public string Password { get; set; }

        [Required]
        public double KcalGoal { get; set; } = 1800;

        [Required]
        public double ProteinGoal { get; set; } = 160;

        [Required]
        public double CarbohydrateGoal { get; set; } = 150;

        [Required]
        public double FatGoal { get; set; } = 50;

        [Required]
        public double FibreGoal { get; set; } = 35;

        // Tilføjelse til Harris-Benedict
        public string Gender { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }




        // constructor
        public User(string name, string email, string password, double kcalgoal, double proteingoal, double carbohydrategoal, double fatgoal, string gender, double weight, double height, int age)
        {
            Name = name;
            Email = email;
            Password = password;
            KcalGoal = kcalgoal;
            ProteinGoal = proteingoal;
            CarbohydrateGoal = carbohydrategoal;
            FatGoal = fatgoal;
            Gender = gender;
            Weight = weight;
            Height = height;
            Age = age;


        }

        // defaul constructor
        public User()
        {
            
        }

        // method 
        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Password: {Password}";
        }



        // Harris Benedict metode
        public double CalculateBmr()
        {
            double bmr = 0;

            if (Gender == "Kvinde")
            {
                bmr = FemaleBaseConstant
                      + (FemaleWeightConstant * Weight)
                      + (FemaleHeightConstant * Height)
                      - (FemaleAgeConstant * Age);
            }
            else
            {
                bmr = MaleBaseConstant
                      + (MaleWeightConstant * Weight)
                      + (MaleHeightConstant * Height)
                      - (MaleAgeConstant * Age);
            }

            return bmr * 1.5; // Multiplicér med aktivitetsniveau (1.5 for moderat aktivitet)
        }
    }
}
