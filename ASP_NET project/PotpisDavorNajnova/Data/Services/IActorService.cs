using PotpisDavorNajnova.Models;

namespace PotpisDavorNajnova.Data.Services
{
    public interface IActorService
    {

        Task<IEnumerable<Actor>> GetAllAsync();

       Task <Actor> GetbyidAsync(int id);

       Task AddAsync(Actor actor);

       Task <Actor> UpdateAsync(int id, Actor Newactor);

        Task  DeleteAsync(int id);
        object GetActorByFullName(string fullName);
    }
}
