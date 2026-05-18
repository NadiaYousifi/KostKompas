using KostKompas.MockData;
using KostKompas.Models;

namespace KostKompas.Services
{
    public class UserService
    {
        private List<User> _users;
        private DbGenericService<User> _dbService;

        public UserService(DbGenericService<User> dbService)
        {
            _dbService = dbService;
            //_users = MockUsers.GetMockUsers();
            //_dbService.SaveObjectsAsync(_users);
            _users = _dbService.GetObjectsAsync().Result.ToList();
        }

        // AddUser metode
        public async Task AddUserAsync(User user)
        {
            _users.Add(user);
            await _dbService.AddObjectAsync(user); 
        }

        public async Task<List<User>> GetUsersAsync()
        {
            await _dbService.GetObjectsAsync();
            return _users;
        }


        public async Task UpdateUserAsync(User user)
        {
            if (user != null)
            {
                foreach (User u in _users)
                {
                    if (u.Email == user.Email)
                    {
                        u.Name = user.Name;
                        u.Email = user.Email;
                        u.Age = user.Age;
                        u.Gender = user.Gender;
                        u.Weight = user.Weight;
                        u.Height = user.Height;

                    }
                }
                await _dbService.UpdateObjectAsync(user);
                //_foodLogDbService.SaveObjects(_users);
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            //foreach (User u in _users)
            //{
            //    if (u.Id == id)
            //    {
            //        return u;
            //    }
            //}
            return await _dbService.GetObjectByIdAsync(id);
            throw new ArgumentException("Invalid Id");
        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            foreach (User u in _users)
            {
                if (u.Email == email)
                {
                    await _dbService.GetObjectByIdAsync(u.Id);
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
                //_foodLogDbService.SaveObjects(_users);
            }
            return userToBeDeleted;
        }
    }
}
