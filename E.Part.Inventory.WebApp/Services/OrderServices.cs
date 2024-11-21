using E.Part.Inventory.WebApp.DataAccess.Context;

namespace E.Part.Inventory.WebApp.Services;

public class OrderServices
{
    private readonly EPartInventoryContext _context;
    
    public OrderServices(EPartInventoryContext context)
    {
        _context = context;
    }
    
}