using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmOperationsWithDb
{
    internal class AtmDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        
        public void SeedDatabase()
        {
            if (!Users.Any())
            {
                Users.AddRange(new List<User>
                {
                    new User { CardNumber = "1111", Pin = "1111", Balance = 1000.00m },
                    new User { CardNumber = "2222", Pin = "2222", Balance = 500.00m },
                    new User { CardNumber = "3333", Pin = "3333", Balance = 750.00m }
                });

                SaveChanges();
                Console.WriteLine("Database seeded with default users.");
            }
        }

    }
}
