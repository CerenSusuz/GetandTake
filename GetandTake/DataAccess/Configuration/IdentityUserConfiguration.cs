using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GetandTake.DataAccess.Configuration;

public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
{
    public void Configure(EntityTypeBuilder<IdentityUser> builder)
    {
        builder.HasKey(primaryId => primaryId.Id);
        builder.Property(property => property.UserName).HasMaxLength(256);
        builder.HasMany<IdentityUserClaim<string>>()
            .WithOne()
            .HasForeignKey(foreignKey => foreignKey.UserId)
            .IsRequired();
    }
}