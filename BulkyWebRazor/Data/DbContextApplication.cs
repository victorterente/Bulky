using BulkyWebRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor.Data
{
    public class DbContextApplication : DbContext
    {
        public DbContextApplication(DbContextOptions<DbContextApplication> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Action",
                    DisplayOrder = 1,
                },
                new Category
                {
                    Id = 2,
                    Name = "Scify",
                    DisplayOrder = 12,
                },
                new Category
                {
                    Id = 3,
                    Name = "History",
                    DisplayOrder = 7,
                });
           
        }
    }
}
