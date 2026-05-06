namespace KostKompas.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetObjectsAsync();
        Task AddObjectAsync(T obj);
        Task SaveObjects(List<T> objs);
        Task DeleteObjectAsync(T obj);
        Task UpdateObjectAsync(T obj);
        Task<T> GetObjectByIdAsync(int id);
        Task<T> GetObjectByDateAsync(DateTime date);
    }
}
