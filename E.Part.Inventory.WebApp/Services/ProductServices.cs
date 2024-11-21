using AutoMapper;
using E.Part.Inventory.WebApp.DataAccess.Context;
using E.Part.Inventory.WebApp.DTOs;
using Microsoft.EntityFrameworkCore;

namespace E.Part.Inventory.WebApp.Services;

public class ProductServices
{
    private readonly EPartInventoryContext _context;
    private readonly IMapper _mapper;

    public ProductServices(EPartInventoryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}