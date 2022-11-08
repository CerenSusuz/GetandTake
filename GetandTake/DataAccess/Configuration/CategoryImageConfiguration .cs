using GetandTake.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetandTake.DataAccess.Configuration;

public class CategorImageConfiguration : IEntityTypeConfiguration<CategoryImage>
{
    public void Configure(EntityTypeBuilder<CategoryImage> builder)
    {
        builder.ToTable("CategoryImages");
        builder.Property(prop => prop.CategoryId).IsRequired();
    }
}
