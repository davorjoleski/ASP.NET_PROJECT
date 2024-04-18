using Microsoft.EntityFrameworkCore;
using PotpisDavorNajnova.Models;

namespace PotpisDavorNajnova.Data.Services
{
    public class ACtorsService : IActorService
    {
        private readonly ApplicationDbContext _context;

        public ACtorsService(ApplicationDbContext context)
        {

            _context = context;
        }
        public async Task AddAsync(Actor actor)
        {
             await _context.Actors.AddAsync(actor);
               await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.id == id);
             _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

        public object GetActorByFullName(string fullName)
        {
            var existingActor = _context.Actors.FirstOrDefault(a => a.FullName == fullName);
            return existingActor;
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
                var results= await  _context.Actors.ToListAsync();
            return results;
        }

        public async Task <Actor> GetbyidAsync(int id)
        {

            var result = await _context.Actors.FirstOrDefaultAsync(n => n.id == id);
            return result;
            }

        

      
        public async Task<Actor> UpdateAsync(int id, Actor Newactor)
        {
            _context.Update(Newactor);
            await _context.SaveChangesAsync();
            return Newactor;
        }


    }
}
