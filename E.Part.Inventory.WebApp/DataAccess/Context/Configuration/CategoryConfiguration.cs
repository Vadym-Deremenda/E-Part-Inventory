using E.Part.Inventory.WebApp.DataAccess.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E.Part.Inventory.WebApp.DataAccess.Context.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.CategoryName)
                .IsRequired();

            builder.HasMany(c => c.Products)
                .WithOne(p => p.ProductCategory)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
