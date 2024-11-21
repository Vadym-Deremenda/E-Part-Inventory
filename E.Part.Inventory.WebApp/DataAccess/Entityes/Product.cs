namespace E.Part.Inventory.WebApp.DataAccess.Entityes
{
    public class Product : BaseEntity
    {
        public string? ProductName { get; set; }
        public string? Manufacturer { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string? Currency { get; set; }
        public int? QuantityInStock { get; set; }

        public virtual Category ProductCategory { get; set; }
        internal virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}