using Microsoft.EntityFrameworkCore;
using BulkyWeb.Models;
namespace BulkyWeb.Date
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData
                (
                new { Id = 1, Name = "Laptop", Price = 1000 },
                new { Id = 2, Name = "Tv", Price = 2000 },
                new { Id = 3, Name = "Phone", Price = 3000 }
                );
        }
    }
}
