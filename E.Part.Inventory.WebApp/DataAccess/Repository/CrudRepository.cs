using E.Part.Inventory.WebApp.DataAccess.Context;
using E.Part.Inventory.WebApp.DataAccess.Entityes;
using E.Part.Inventory.WebApp.DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace E.Part.Inventory.WebApp.DataAccess.Repository
{
    public class CrudRepository<T> : ICrudRepository<T> where T : BaseEntity
    {
        private readonly EPartInventoryContext _context;

        public CrudRepository(EPartInventoryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(s => s.Id == id);
            if (entity != null)
            {
                return entity;
            }
            throw new Exception($"Сутність типу {typeof(T)} з Id:{id} - не знайдено");
        }

        public async Task UpdateAsync(T entity)
        {
            if (await _context.Set<T>().FindAsync(entity.Id) is T found)
            {
                _context.Set<T>().Entry(found).State = EntityState.Detached;
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return;
            }
            throw new Exception("Error Update");
        }

        public async Task DeleteAsync(int id)
        {
            _context.Set<T>().Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

       

       
    }
}
