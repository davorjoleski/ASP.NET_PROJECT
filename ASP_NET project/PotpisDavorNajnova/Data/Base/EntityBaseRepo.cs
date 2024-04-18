using PotpisDavorNajnova.Models;

namespace PotpisDavorNajnova.Data.Base
{
    public interface EntityBaseRepo<T> where T : class, IEntityBase, new()
    {

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetbyidAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);
    }
}
