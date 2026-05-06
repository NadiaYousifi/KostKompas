using KostKompas.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KostKompas.Data;


        public class KostKompasDbContext : DbContext
        {
            public KostKompasDbContext(DbContextOptions<KostKompasDbContext> options)
                : base(options)
            {
            }

            public DbSet<Food> Foods { get; set; }
            public DbSet<User> Users { get; set; }
           
        }

    

