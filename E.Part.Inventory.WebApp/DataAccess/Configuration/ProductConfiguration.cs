using E.Part.Inventory.WebApp.DataAccess.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E.Part.Inventory.WebApp.DataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(p=>p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.ProductCode)
                .IsRequired();

            builder.Property(p => p.ProductName)
                .IsRequired();

            builder.Property(p => p.Manufacturer)
                .IsRequired();

            builder.Property(p=>p.CategoryId)
                .IsRequired();

            builder.Property(p=>p.Price)
                .IsRequired();

            builder.Property(p=>p.Currency)
                .IsRequired();

            builder.Property(p => p.QuantityInStock)
                .IsRequired();
        }
    }
}
