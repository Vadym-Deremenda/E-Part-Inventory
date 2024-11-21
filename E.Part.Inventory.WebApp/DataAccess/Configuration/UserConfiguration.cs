using E.Part.Inventory.WebApp.DataAccess.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E.Part.Inventory.WebApp.DataAccess.Configuration;

public class UserConfiguration:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.UserName)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(50);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Role)
            .HasConversion(
                u => u.ToString(),
                u=>(Role)Enum.Parse(typeof(Role),u)
                )
            .IsRequired();

    }
}