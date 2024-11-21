namespace E.Part.Inventory.WebApp.DataAccess.Entityes;

public class OrderDetails
{
    public int  OrderId { get; set; }
    public int ProductId { get; set; }

    public int Quantity { get; set; }
    public decimal PriceAtOrderTime { get; set; }
    public decimal LineTotal { get; set; }

    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }
}