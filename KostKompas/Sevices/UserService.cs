using KostKompas.MockData;
using KostKompas.Models;

namespace KostKompas.Sevices
{
    public class UserService
    {

        private List<User> users;



        // constructor
        public UserService()
        {
            users = MockUsers.GetMockUsers();
            //{
            //new Models.User("Louise", "louiselr_2@live.dk","0207", 1),
            //new Models.User("Nadia", "emial@live.dk", "0033", 2),
            //new Models.User("Emil", "email@live.com", "3030", 3)
            //};
        }




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
                    if (u.Id == user.Id)
                    {
                        u.Name = user.Name;
                        u.Email = user.Email;
                        u.Password = user.Password;
                    }
                }
            }
        }



        // GetById
        public User GetUser(int id)
        {
            foreach (User u in users)
            {
                if (u.Id == id)
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
                if (user.Id == id)
                {
                    userToBeDeleted = user;
                    break;
                }

            }
            if (userToBeDeleted != null)
            {
                users.Remove(userToBeDeleted);
            }
            return userToBeDeleted;



        }
    }
}
