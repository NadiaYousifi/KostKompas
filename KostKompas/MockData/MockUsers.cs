using KostKompas.Models;
using Microsoft.AspNetCore.Identity;

namespace KostKompas.MockData
{
    public class MockUsers
    {
        private static PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
        private static List<User> _users = new List<User>()
        {
            new User(1, "Admin", "A@mail.com", passwordHasher.HashPassword(null, "secret")),
            new User(2, "Nadia", "Nadia@mail.com", passwordHasher.HashPassword(null, "12345")),
            new User(3, "Emil", "Emil@mail.com", passwordHasher.HashPassword(null, "12345")),
            new User(4, "Mathias", "Mathias@mail.com", passwordHasher.HashPassword(null, "12345")),
            new User(5, "Louise", "Louise@mail.com", passwordHasher.HashPassword(null, "12345"))
        };

        public static List<User> GetMockUsers()
        {
            return _users;
        }
    }
}
