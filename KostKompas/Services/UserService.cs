using KostKompas.MockData;
using KostKompas.Models;

namespace KostKompas.Services
{
    public class UserService
    {
        private List<User> _users;

        public UserService()
        {
            _users = MockUsers.GetMockUsers();
        }


        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public List<User> GetUsers()
        {
            return _users;
        }


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
