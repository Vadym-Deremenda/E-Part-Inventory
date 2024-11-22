namespace E.Part.Inventory.WebApp.DTOs;

public class OrderHistoryDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int UserId { get; set; }
    public decimal Total { get; set; }
}