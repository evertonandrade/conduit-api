using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Conduit.Api.Entities.Users;

using LanguageExt.SomeHelp;

using Microsoft.AspNetCore.Identity;

namespace Conduit.Api.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);
        builder
            .Property(u => u.Id)
            .HasConversion(id => id.Value, value => new UserId(value))
            .ValueGeneratedNever()
            .HasColumnName("id");
        builder
            .Property(u => u.UserName)
            .HasConversion(username => username.ToString(), value => UserName.Parse(value))
            .HasMaxLength(32)
            .HasColumnName("username")
            .IsUnicode()
            .IsRequired();
        builder.HasIndex(u => u.UserName).IsUnique();
        builder
            .Property(u => u.Email)
            .HasConversion(email => email.ToString(), str => str)
            .HasMaxLength(320)
            .HasColumnName("email")
            .IsRequired();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.Password).HasColumnName("password");
        builder.Property(u => u.Bio).HasColumnName("bio");
        builder.Property(u => u.ImageUrl).HasColumnName("image_url");
    }
}
