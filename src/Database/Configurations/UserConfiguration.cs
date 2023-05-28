using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Conduit.Api.Entities.Users;

namespace Conduit.Api.Database.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);
        builder
            .Property(u => u.Id)
            .HasConversion(id => id.Value, guid => new UserId(guid))
            .ValueGeneratedNever()
            .HasColumnName("id");
        builder
            .Property(u => u.UserName)
            .HasConversion(username => username.ToString(), username => username)
            .HasMaxLength(32)
            .HasColumnName("username")
            .IsUnicode()
            .IsRequired();
        builder
            .Property(u => u.Email)
            .HasConversion(email => email.ToString(), str => str)
            .HasMaxLength(320)
            .HasColumnName("email")
            .IsRequired();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.Bio).HasColumnName("bio");
        builder.Property(u => u.ImageUrl).HasColumnName("image_url");
    }
}