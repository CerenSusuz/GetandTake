using GetandTake.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetandTake.DataAccess.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.Property(property => property.ProductName).IsRequired();
        builder
            .HasOne<Category>()
            .WithMany(category => category.Products)
            .HasForeignKey(product => product.CategoryID)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(required: false);

        builder
            .HasOne<Supplier>()
            .WithMany(supplier => supplier.Products)
            .HasForeignKey(product => product.SupplierID)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(required: false);
    }
}
