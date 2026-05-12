namespace KostKompas.Services
{
    public interface IService<T, V>
    {
        Task<IEnumerable<T>> GetObjectsAsync();
        Task AddObjectAsync(T obj);
        Task SaveObjectsAsync(List<T> objs);
        Task DeleteObjectAsync(T obj);
        Task UpdateObjectAsync(T obj);
        Task<T> GetObjectByIdAsync(V pk);
    }
}
