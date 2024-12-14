using CakeShopProject.Data.Mappings;
using CakeShopProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CakeShopProject.Data.Context;

public class CakeShopContext : DbContext
{
    public CakeShopContext(DbContextOptions<CakeShopContext> options) : base(options) { }

    /// <summary>
    /// Representação das tabelas
    /// </summary>
   
    public DbSet<State> State { get; set; }
    public DbSet<City> City { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Product> Product { get; set; }
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientMap).Assembly);
    }
}
