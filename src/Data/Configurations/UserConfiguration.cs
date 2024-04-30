using Conduit.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conduit.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(320);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(64);
        builder.OwnsOne(
            u => u.Profile,
            profileBuilder =>
            {
                profileBuilder.ToTable("profile");
                profileBuilder.Property(u => u.Username).HasMaxLength(32);
                profileBuilder.Property(u => u.Bio).HasMaxLength(150);
                profileBuilder.Property(u => u.ImageUrl).HasMaxLength(10_000);
            }
        );
    }
}
