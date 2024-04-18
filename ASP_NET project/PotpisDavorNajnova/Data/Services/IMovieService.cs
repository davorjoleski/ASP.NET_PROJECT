using PotpisDavorNajnova.Data.Base;
using PotpisDavorNajnova.Models;

namespace PotpisDavorNajnova.Data.Services
{
    public interface IMovieService:EntityBaseRepo<Movie>
    {

        Task AddnewMovie(NewMovieVm vm);
        Task AddNewMovieAsync(NewMovieVm data);
        Task<NewMovieDropdown> GetNewMovieDropdownsValues();


    }
}
