using KostKompas.MockData;
using KostKompas.Models;

namespace KostKompas.Services
{
    public class UserService
    {
        private List<User> _users;
        private DbGenericService<User, string> _dbService;

        public UserService(DbGenericService<User, string> dbService)
        {
            _users = MockUsers.GetMockUsers();
            _dbService = dbService;
            _dbService.SaveObjectsAsync(_users);
            //_users = _dbService.GetObjectsAsync().Result.ToList();
        }

        public async Task AddUserAsync(User user)
        {
            _users.Add(user);
            await _dbService.AddObjectAsync(user);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            await _dbService.GetObjectsAsync();
            return _users;
            //_dbService.SaveObjects(_users);
        }

        public async Task UpdateUserAsync(User user)
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
                await _dbService.UpdateObjectAsync(user);
                //_dbService.SaveObjects(_users);
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            foreach (User u in _users)
            {
                if (u.Id == id)
                {
                    await _dbService.GetObjectByIdAsync(u.Email);
                    return u;
                }
            }
            throw new ArgumentException("Invalid Id");
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            foreach (User u in _users)
            {
                if (u.Email == email)
                {
                    await _dbService.GetObjectByIdAsync(u.Email);
                    return u;
                }
            }
            throw new ArgumentException("Invalid Id");
        }
        public async Task<User> DeleteUserAsync(int? userId)
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
                await _dbService.DeleteObjectAsync(userToBeDeleted);
                //_dbService.SaveObjects(_users);
            }
            return userToBeDeleted;
        }

    }
}
