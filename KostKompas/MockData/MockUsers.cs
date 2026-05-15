using KostKompas.Models;
using Microsoft.AspNetCore.Identity;

namespace KostKompas.MockData
{
    public class MockUsers
    {
        private static PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

        private static List<User> users = new List<User>()
        {

            new User("Admin", "admin@gmail.com", passwordHasher.HashPassword(null, "456"),1800, 160, 150, 50,"Kvinde", 65, 170, 24),

            new User("Mathias", "123@gmail.com", passwordHasher.HashPassword(null, "123"),2800, 180, 250, 80,"Mand", 82, 185, 26),

            new User("Nadia", "234@gmail.com",passwordHasher.HashPassword(null, "234"),2000, 140, 180, 60,"Kvinde", 58, 168, 22),

            new User( "Emil", "345@gmail.com",passwordHasher.HashPassword(null, "345"),3000, 200, 320, 90,"Mand", 92, 192, 28)

        };

        public static List<User> GetMockUsers()
        {
            return users;
        }
    }
}
