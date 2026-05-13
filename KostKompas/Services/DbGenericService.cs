using KostKompas.EFDbContext;
using Microsoft.EntityFrameworkCore;
using KostKompas.EFDbContext;

namespace KostKompas.Services
{
    public class DbGenericService<T, V> : IService<T, V> where T : class
    {
        public async Task<IEnumerable<T>> GetObjectsAsync()
        {
            using (var context = new KostKompasDbContext())
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task AddObjectAsync(T obj)
        {
            using (var context = new KostKompasDbContext())
            {
                context.Set<T>().Add(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task SaveObjectsAsync(List<T> objs)
        {
            using (var context = new KostKompasDbContext())
            {
                foreach (T obj in objs)
                {
                    context.Set<T>().Add(obj);
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }

        public async Task DeleteObjectAsync(T obj)
        {
            using (var context = new KostKompasDbContext())
            {
                context.Set<T>().Remove(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateObjectAsync(T obj)
        {
            using (var context = new KostKompasDbContext())
            {
                context.Set<T>().Update(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task<T> GetObjectByIdAsync(V pk)
        {
            using (var context = new KostKompasDbContext())
            {
                return await context.Set<T>().FindAsync(pk);
            }
        }

    }
}