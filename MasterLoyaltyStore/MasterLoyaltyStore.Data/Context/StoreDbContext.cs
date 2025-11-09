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

    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    { }
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplicar todas las configuraciones del assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}