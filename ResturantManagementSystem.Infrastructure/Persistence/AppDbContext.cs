using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using ResturantManagementSystem.Domain;
using ResturantManagementSystem.Domain.Entities;

namespace ResturantManagementSystem.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetSection("ConnectionString").Value;

            optionsBuilder.ConfigureWarnings(w =>
                  w.Ignore(RelationalEventId.PendingModelChangesWarning));

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
