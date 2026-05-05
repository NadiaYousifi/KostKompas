namespace KostKompas.Models
{
    public class User
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public double Kcal_goal { get; } = 1800;
        public double Protein_goal { get; } = 160;
        public double Fat_goal { get; } = 150;
        public double Carbohydrate_goal { get; } = 50;
        public double Fibre_goal { get; } = 35;

       

        
        public User()
        {

        }

        public User(int id, string name, string email, string password, double kcal_goal, double protein_goal, double fat_goal, double carbohydrate_goal, double fibre_goal)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Kcal_goal = kcal_goal;
            Protein_goal = protein_goal;
            Fat_goal = fat_goal;
            Carbohydrate_goal = carbohydrate_goal;
            Fibre_goal = fibre_goal;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Password: {Password}";
        }
    }
}
