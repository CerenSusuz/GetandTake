using GetandTake.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GetandTake.Core.Models.Account;

namespace GetandTake.DataAccess;

public class NorthwindDbContext : IdentityDbContext<ApplicationUser>
{
    public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("Identity");
        modelBuilder.Entity<IdentityUser>(entity =>
        {
            entity.ToTable(name: "User");
        });
        modelBuilder.Entity<IdentityRole>(entity =>
        {
            entity.ToTable(name: "Role");
        });
        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.ToTable("UserRoles");
        });
        modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.ToTable("UserClaims");
        });
        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable("UserLogins");
        });
        modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.ToTable("RoleClaims");
        });
        modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.ToTable("UserTokens");
        });

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NorthwindDbContext).Assembly);        
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }
}