using AutoMapper;
using E.Part.Inventory.WebApp.DataAccess.Context;
using E.Part.Inventory.WebApp.DataAccess.Entityes;
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
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
    public async Task<Product> GetProductAsync(int id)
    {
        var data = await _context.Products.Include(c => c.ProductCategory).FirstOrDefaultAsync(c => c.Id == id);
        if (data != null)
        {
            return data;
        }
        throw new Exception("Product не знайдена");
    }
    public async Task AddProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateProductAsync(Product product)
    {
        if (await _context.Products.FindAsync(product.Id) is Product found)
        {
            _context.Products.Entry(found).State = EntityState.Detached;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return;
        }
        throw new Exception("Error update");
    }
    public async Task DeleteProductAsync(int id)
    {
        var entity = await _context.Products.FirstOrDefaultAsync(e => e.Id == id);
        if (entity != null)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
            return;
        }
        throw new Exception("Не знайдено");
    }
}