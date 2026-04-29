namespace KostKompas.Models
{
    public class User
    {
        // properties 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }

        // constructor 
        public User(string name, string email, string password, int id)
        {
            Name = name;
            Email = email;
            Password = password;
            Id = id;
        }

        // defaul constructor
        public User()
        {

        }

        // method 
        public override string ToString()
        {
            return $"{Name}, name: {Email}, email: {Password}, password:";
        }
    }
}
