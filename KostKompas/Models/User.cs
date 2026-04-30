namespace KostKompas.Models
{
    public class User
    {
        // properties 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }

        

        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            
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
