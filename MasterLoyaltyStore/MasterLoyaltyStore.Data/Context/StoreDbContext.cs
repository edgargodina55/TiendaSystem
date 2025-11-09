using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace MasterLoyaltyStore.Data.Context;

public class StoreDbContext : DbContext
{


    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplicar todas las configuraciones del assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}