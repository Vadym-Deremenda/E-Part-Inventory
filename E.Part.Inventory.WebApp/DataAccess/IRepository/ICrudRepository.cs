using E.Part.Inventory.WebApp.DataAccess.Entityes;

namespace E.Part.Inventory.WebApp.DataAccess.IRepository
{
    public interface ICrudRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
