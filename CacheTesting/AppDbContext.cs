using CacheTesting.Models;
using Microsoft.EntityFrameworkCore;

namespace CacheTesting
{
    public class AppDbContext :DbContext
    {
        public DbSet<Entity> Entities { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entities = new List<Entity>()
            {
                new Entity { Id = 1, Name = "Name1", Description = "Description1" },
                new Entity { Id = 2, Name = "Name2", Description = "Description2" },
                new Entity { Id = 3, Name = "Name3", Description = "Description3" },
            };
            modelBuilder.Entity<Entity>().HasData(entities);
        }
    }
}
