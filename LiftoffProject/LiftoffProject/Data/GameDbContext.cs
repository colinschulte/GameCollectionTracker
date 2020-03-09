using LiftoffProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace LiftoffProject.Data
{
        public class GameDbContext : DbContext
    {
        public DbSet<Cover> Covers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreGameId> GenreGameIds { get; set; }
        public DbSet<Image> Screenshots { get; set; }



        public GameDbContext(DbContextOptions<GameDbContext> options) 
            : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreGameId>()
                .HasKey(g => new { g.GenreId, g.GameId });
            
            base.OnModelCreating(modelBuilder);
        }

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
