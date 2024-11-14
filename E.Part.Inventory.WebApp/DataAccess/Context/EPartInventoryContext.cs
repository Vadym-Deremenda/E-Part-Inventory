using E.Part.Inventory.WebApp.DataAccess.Entityes;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace E.Part.Inventory.WebApp.DataAccess.Context
{
    public class EPartInventoryContext:DbContext
    {
        public EPartInventoryContext(DbContextOptions<EPartInventoryContext> options): base(options) 
        {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
