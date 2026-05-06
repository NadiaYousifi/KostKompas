using KostKompas.Data;
using KostKompas.Models;
using Microsoft.EntityFrameworkCore;

namespace KostKompas.Services
{
    public class DbService <T> : IService<T>  where T : class
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

        public async Task<T> GetObjectByIdAsync(int id)
        {
            using (var context = new KostKompasDbContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public async Task<T> GetObjectByDateAsync(DateTime date)
        {
            using (var context = new KostKompasDbContext())
            {
                return await context.Set<T>().FindAsync(date);
            }
        }


    }
}
