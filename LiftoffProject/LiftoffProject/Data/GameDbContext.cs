using LiftoffProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LiftoffProject.Data
{
        public class GameDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Cover> Covers { get; set; }
        //public DbSet<ReleaseDate> ReldeaseDates { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options) 
            : base(options) 
        { }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GameDbContext>
    {
        public GameDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<GameDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new GameDbContext(builder.Options);
        }
    }
}
