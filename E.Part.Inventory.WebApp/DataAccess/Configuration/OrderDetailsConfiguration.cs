using E.Part.Inventory.WebApp.DataAccess.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E.Part.Inventory.WebApp.DataAccess.Configuration;

public class OrderDetailsConfiguration:IEntityTypeConfiguration<OrderDetails>
{
    public void Configure(EntityTypeBuilder<OrderDetails> builder)
    {
        builder.HasKey(od=>new {od.OrderId,od.ProductId});

        builder.HasOne(od => od.Order)
            .WithMany(o => o.OrderDetalis)
            .HasForeignKey(or => or.OrderId); 
        
        builder.HasOne(od => od.Product)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(or => or.ProductId);
    }
}