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
            .HasOne(product => product.Category)
            .WithMany(category => category.Products)
            .HasForeignKey(category => category.CategoryID)
            .IsRequired(required: false);

        builder
           .HasOne(product => product.Supplier)
           .WithMany(suplier => suplier.Products)
           .HasForeignKey(suplier => suplier.SupplierID)
           .IsRequired(required: false);
    }
}