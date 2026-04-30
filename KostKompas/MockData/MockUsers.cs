using KostKompas.Models;
using Microsoft.AspNetCore.Identity;

namespace KostKompas.MockData
{
    public class MockUsers
    {
        private static PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

        private static List<User> users = new List<User>() 
        {
           new User(1,"Admin", "456@gmail.com", passwordHasher.HashPassword(null, "456")),
           new User(2,"Mathias","123@gmail.com", passwordHasher.HashPassword(null, "123")),
           new User(3, "Nadia", "234@gmail.com",  passwordHasher.HashPassword(null, "234")),
           new User(4,"Emil", "345@gmail.com", passwordHasher.HashPassword(null, "345"))

        };

       
           
        

        public static List<User> GetMockUsers()
        {
            return users;
        }
        // metode
        private static PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

        private static List<User> Users = new List<User>()
        {
            new User("admin", "admin@hotmail.dk", passwordHasher.HashPassword(null, "secret"), 5),
            new User("Louise", "louiselr_2@live.dk", passwordHasher.HashPassword(null, "123"), 6),
            new User("Nadia", "nadia@hotmial.dk", passwordHasher.HashPassword(null, "123"), 7)
        };
    }
}
    


