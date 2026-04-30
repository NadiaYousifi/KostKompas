using KostKompas.Models;
using Microsoft.AspNetCore.Identity;

namespace KostKompas.MockData
{
    public class MockUsers
    {
        static List<User> users = new List<User>()
        {
            new User("Louise", "louiselr_2@live.dk", "0207", 1),
            new User("Nadia", "nadia@hotmail.dk", "3030", 2),
            new User("Mathias", "mathias@hotmial.dk", "4040", 3),
            new User("Emil", "emil@hotmail.dk", "2020", 4)
        };

        // metode
        public static List<User> GetMockUsers()
        {
            return Users;
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
    


