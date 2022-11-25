using GetandTake.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetandTake.DataAccess.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.Property(prop => prop.CategoryName).IsRequired();

        builder
            .HasMany(category => category.Products)
            .WithOne(product => product.Category)
            .IsRequired()
            .OnDelete(DeleteBehavior.SetNull);
    }
}