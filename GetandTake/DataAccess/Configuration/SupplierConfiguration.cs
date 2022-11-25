using GetandTake.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetandTake.DataAccess.Configuration;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers");
        builder.Property(prop => prop.CompanyName).IsRequired();

        builder
           .HasMany(supplier => supplier.Products)
           .WithOne(product => product.Supplier)
           .IsRequired()
           .OnDelete(DeleteBehavior.SetNull);
    }
}