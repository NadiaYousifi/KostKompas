using KostKompas.MockData;
using KostKompas.Models;

namespace KostKompas.Services
{
    public class UserService
    {
        // instance fields
        private List<User> _users;

        // constructor 
        public UserService()
        {
            _users = MockUsers.GetMockUsers();
        }

        // Add metode
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        // 
        public List<User> GetUsers()
        {
            return _users;
        }

        // Update metode
        public void UpdateUser(User user)
        {
            if (user != null)
            {
                foreach (User u in _users)
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

        // GetUserById metode
        public User? GetUserById(int id)
        {
            foreach (User u in _users)
            {
                if (u.Id == id)
                {
                    return u;
                }
            }
            throw new ArgumentException("Invalid Id");
        }

       // DeleteUser metode
        public User DeleteUser(int? userId)
        {
            User userToBeDeleted = null;
            foreach (User u in _users)
            {
                if (u.Id == userId)
                {
                    userToBeDeleted = u;
                    break;
                }

            }
            if (userToBeDeleted != null)
            {
                _users.Remove(userToBeDeleted);
            }
            return userToBeDeleted;
        }
    }
}
