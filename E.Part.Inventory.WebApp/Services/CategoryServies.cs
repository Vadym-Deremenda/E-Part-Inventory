using AutoMapper;
using E.Part.Inventory.WebApp.DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace E.Part.Inventory.WebApp.Services;

public class CategoryServies
{
    private readonly EPartInventoryContext _context;
    private readonly IMapper _mapper;

    public CategoryServies(EPartInventoryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}