using System.Reflection;
using MasterLoyaltyStore.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterLoyaltyStore.Data.Context;

public class StoreDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<UserType> UserTypes { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }


    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    { }
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplicar todas las configuraciones del assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Cart>()
            .HasOne(c => c.User)
            .WithMany()              // si luego quieres navegar desde User, aquí pones .WithMany(u => u.Carts)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // CartItem -> Cart (1:N)
        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Cart)
            .WithMany(c => c.Items)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        // CartItem -> Product (1:N)
        modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.Product)
            .WithMany()              // puedes luego agregar en Product una ICollection<CartItem>
            .HasForeignKey(ci => ci.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}