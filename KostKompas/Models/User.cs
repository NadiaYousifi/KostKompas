using System.ComponentModel.DataAnnotations;

namespace KostKompas.Models
{
    public class User
    {
        // properties 
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
     
        public int Id { get; set; }

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



        public User(int id, string name, string email, string password, double kcalgoal, double proteingoal, double carbohydrategoal, double fatgoal)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            KcalGoal = kcalgoal;
            ProteinGoal = proteingoal;
            CarbohydrateGoal = carbohydrategoal;
            FatGoal = fatgoal;


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
    }
}
