using GetandTake.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GetandTake.DataAccessLayer.EF
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

    }
}
