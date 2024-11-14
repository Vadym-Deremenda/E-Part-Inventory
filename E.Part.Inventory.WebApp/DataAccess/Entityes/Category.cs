namespace E.Part.Inventory.WebApp.DataAccess.Entityes
{
    public class Category : BaseEntity
    {
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        public virtual IEnumerable<Product>? Products { get; set; }
    }
}
