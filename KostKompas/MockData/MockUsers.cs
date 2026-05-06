using KostKompas.Models;
using Microsoft.AspNetCore.Identity;

namespace KostKompas.MockData
{
    public class MockUsers
    {
        private static PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

        private static List<User> users = new List<User>()
        {
           new User(1,"Admin", "admin@gmail.com", passwordHasher.HashPassword(null, "456"), 1800, 160, 150, 50, 35),
           new User(2,"Mathias","123@gmail.com", passwordHasher.HashPassword(null, "123"), 1800, 160, 150, 50, 35),
           new User(3, "Nadia", "234@gmail.com",  passwordHasher.HashPassword(null, "234"), 1800, 160, 150, 50, 35),
           new User(4,"Emil", "345@gmail.com", passwordHasher.HashPassword(null, "345"), 1800, 160, 150, 50, 35)
        };

        public static List<User> GetMockUsers()
        {
            return users;
        }
    }
}
