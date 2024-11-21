using AutoMapper;
using E.Part.Inventory.WebApp.DataAccess.Context;
using E.Part.Inventory.WebApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace E.Part.Inventory.WebApp.Services;

public class OrderServices
{
    private readonly EPartInventoryContext _context;
    private readonly IMapper _mapper;
    
    public OrderServices(EPartInventoryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderHistoryDto>> GetOrderHistory()
    {
        var data = await _context.Orders.ToListAsync();
        return _mapper.Map<List<OrderHistoryDto>>(data);
    }
}