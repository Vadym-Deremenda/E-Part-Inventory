using E.Part.Inventory.WebApp.DataAccess.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E.Part.Inventory.WebApp.DataAccess.Configuration;

public class OrderConfiguration:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.OrederId);

        builder.Property(o => o.OrederId)
            .ValueGeneratedOnAdd();

        builder.Property(o => o.UserId)
            .IsRequired();

        builder.Property(o => o.OrderDate)
            .IsRequired();

        builder.HasMany(o => o.Products)
            .WithMany(p => p.Orders)
            .UsingEntity(e => e.ToTable("OrderDetails"));
    }
}