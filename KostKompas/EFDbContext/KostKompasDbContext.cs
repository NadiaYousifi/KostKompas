using KostKompas.Models;
using Microsoft.EntityFrameworkCore;

namespace KostKompas.EFDbContext
{
    public class KostKompasDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=NADIA\SQLEXPRESS;Initial Catalog=KostKompasEfDb; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<FoodLogDay> FoodLogDays { get; set; }

    }
}
