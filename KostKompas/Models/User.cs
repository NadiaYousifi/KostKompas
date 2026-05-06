using System.ComponentModel.DataAnnotations;

namespace KostKompas.Models
{
    public class User
    {
        // properties 
        [Required(ErrorMessage ="Der skal angives et navn")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Der skal angives et password")]
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



        public User(int id, string name, string email, string password, double kcalGoal, double proteinGoal, double carbohydrateGoal, double fatGoal, double fibreGoal)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            KcalGoal = kcalGoal;
            ProteinGoal = proteinGoal;
            CarbohydrateGoal = carbohydrateGoal;
            FatGoal = fatGoal;
            FibreGoal = fibreGoal;
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
