using Microsoft.EntityFrameworkCore;
using USCJCI.Models;

namespace USCJCI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Item> Items { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().HasData(
                   new Item { Id = 1, Name = "Item 1", Price = 10 },
                   new Item { Id = 2, Name = "Item 2", Price = 20 }
                );

            modelBuilder.Entity<Product>().HasData(
           new Product { Id = 1, Name = "Product 1", Price = 10, Description= "Product 1 Description"},
           new Product { Id = 2, Name = "Product 2", Price = 20, Description = "Product 2 Description" }
        );

        }
    }
}
