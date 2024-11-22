using AutoMapper;
using E.Part.Inventory.WebApp.DataAccess.Context;
using E.Part.Inventory.WebApp.DataAccess.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

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
    public async Task<IEnumerable<Category>> GetAllCategoryAsync()
    {
        return await _context.Categories.ToListAsync();
    }
    public async Task<Category> GetCategoryAsync(int id)
    {
        var data = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
        if (data != null)
        {
            return data;
        }
        throw new Exception("Категорія не знайдена");
    }
    public async Task AddCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return;
    }
    public async Task UpdateCategoryAsync(Category category)
    {
        if (await _context.Categories.FindAsync(category.Id) is Category found)
        {
            _context.Categories.Entry(found).State = EntityState.Detached;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return;
        }
        throw new Exception("Error update");
    }
    public async Task DeleteCategoryAsync(int id)
    {
        var entity=await _context.Categories.FirstOrDefaultAsync(e=>e.Id==id);
        if (entity != null) {
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
            return;
        }
        throw new Exception("Не знайдено");
    }
}