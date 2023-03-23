using System.Reflection.Metadata;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Data.ShopingEntity;

namespace WebApp.Data;

public class ShoppingDbContext : IdentityDbContext
{
    public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ViewOrder>(entity =>
        {
            entity.HasNoKey();
        });

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") {
            var categories = new[] {
                new Category() { Id = Guid.NewGuid(), Name = "Category 1", Description = "Description 1" },
                new Category() { Id = Guid.NewGuid(), Name = "Category 2", Description = "Description 2" },
                new Category() { Id = Guid.NewGuid(), Name = "Category 3", Description = "Description 3" }
            };

            var products = new[] {
                new Product() { Id = Guid.NewGuid(), CategoryId = categories[0].Id, Name = "Product 1", Description = "Description 1", Quantity = 5, Price = 100 },
                new Product() { Id = Guid.NewGuid(), CategoryId = categories[1].Id, Name = "Product 2", Description = "Description 2", Quantity = 4, Price = 200 },
                new Product() { Id = Guid.NewGuid(), CategoryId = categories[2].Id, Name = "Product 3", Description = "Description 3", Quantity = 3, Price = 300 },
            };

            var customer = new[] {
                new Customer() { Id = Guid.NewGuid(), Name = "Customer 1", Address = "Address 1" },
                new Customer() { Id = Guid.NewGuid(), Name = "Customer 2", Address = "Address 2" },
                new Customer() { Id = Guid.NewGuid(), Name = "Customer 3", Address = "Address 3" }
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Customer>().HasData(customer);
        }
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ViewOrder> ViewOrders { get; set; }
}
