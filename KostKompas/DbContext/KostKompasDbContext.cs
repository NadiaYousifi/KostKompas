using KostKompas.Models;
using Microsoft.EntityFrameworkCore;

namespace KostKompas.Data
{
    public class KostKompasDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KostKompasEfDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FoodLogDay> FoodLogDays { get; set; }
        public DbSet<Meal> Meals { get; set; }

    }
}
