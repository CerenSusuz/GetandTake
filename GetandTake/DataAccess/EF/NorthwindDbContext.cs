using GetandTake.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GetandTake.DataAccessLayer.EF
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {
                
        }
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=EPTRANKW0038\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

    }
}
