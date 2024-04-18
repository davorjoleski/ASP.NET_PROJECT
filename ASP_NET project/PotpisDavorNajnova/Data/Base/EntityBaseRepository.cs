using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PotpisDavorNajnova.Models;

namespace PotpisDavorNajnova.Data.Base
{
    public class EntityBaseRepository<T> : EntityBaseRepo<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationDbContext _context;


        public EntityBaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public  async Task AddAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
             _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        { 
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

        }

        public  async Task<IEnumerable<T>> GetAllAsync()
        {
            var results = await _context.Set<T>().ToListAsync(); //to work for everything movie actors cinema
            return results;
        }

        public async Task<T> GetbyidAsync(int id)
        {

            var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.id == id);
            return result;
        }






        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
          
        }
    }
}
