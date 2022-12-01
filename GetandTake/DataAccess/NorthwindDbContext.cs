using GetandTake.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GetandTake.DataAccess;

public class NorthwindDbContext : IdentityDbContext<IdentityUser>
{
    public NorthwindDbContext(
        DbContextOptions<NorthwindDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NorthwindDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }
}