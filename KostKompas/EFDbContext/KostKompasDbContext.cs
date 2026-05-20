
using KostKompas.Models;
using Microsoft.EntityFrameworkCore;

namespace KostKompas.EFDbContext
{
    public class KostKompasDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KostKompasEfDb; Integrated Security=True; Connect Timeout=30; Encrypt=False");
            options.UseSqlServer(@"Data Source=mssql14.unoeuro.com;User ID=simpelwebdev_dk;Password=nGaDAz63h4R2kmHEBdcy;Initial Catalog=simpelwebdev_dk_db_KostKompas;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");

        }


        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<FoodMeal> FoodMeals { get; set; }
        public DbSet<FoodLogDay> FoodLogDays { get; set; }
    }
}
