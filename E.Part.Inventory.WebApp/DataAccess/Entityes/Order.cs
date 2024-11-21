namespace E.Part.Inventory.WebApp.DataAccess.Entityes;

public class Order
{
    public int OrederId { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }

    public virtual ICollection<OrderDetails> OrderDetalis { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}