using KostKompas.Models;

namespace KostKompas.Sevices
{
    public class UserService
    {

        private List<User> users;



        // Add method
        public void AddUser(User user)
        {
            users.Add(user);
        }

        // Get method
        public List<User> GetUsers()
        {
            return users;
        }



        // Update method
        public void UpdateUser(User user)
        {
            if (user != null)
            {
                foreach (User u in users)
                {
                    if (u.id == u.id)
                    {
                        u.Name = user.Name;
                        u.Email = user.Email;
                        u.Password = user.Password;
                    }
                }
            }
        }



        // GetById
        public User? GetUser(int id)
        {
            foreach (User u in users)
            {
                if (u.id == id)
                    return u;
            }
            throw new ArgumentException("User findes ikke");
        }


        // Delete method 
        public User DeleteUser(int? id)
        {
            User userToBeDeleted = null;
            foreach (User user in users)
            {
                if (user.id == id)
                {
                    userToBeDeleted = user;
                    break;
                }

            }
            return userToBeDeleted;



        }
    }
}
