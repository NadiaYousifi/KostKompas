using KostKompas.Models;
using KostKompas.Services;

namespace KostKompas.MockData
{
    public class MockDbService<T> : IDBService<T> where T : class
    {
        public List<T> _mockData { get; set; }
        public MockDbService(List<T> mockData) 
        { 
            _mockData = mockData;
        }

        public async Task AddObjectAsync(T obj)
        {
            _mockData.Add(obj);
        }

        public async Task DeleteObjectAsync(T obj)
        {
        }

        public async Task<T> GetObjectByIdAsync(int pk)
        {
            return _mockData.FirstOrDefault(t => t.Equals(pk));
        }

        public async Task<IEnumerable<T>> GetObjectsAsync()
        {
            return _mockData;
        }

        public async Task SaveObjectsAsync(List<T> objs)
        {
            
        }

        public async Task UpdateObjectAsync(T obj)
        {
        }
    }
}
