using Microsoft.EntityFrameworkCore;
using PotpisDavorNajnova.Data.Base;
using PotpisDavorNajnova.Models;
using System;

namespace PotpisDavorNajnova.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly ApplicationDbContext _context;
        public MoviesService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task AddnewMovie(NewMovieVm vm)
        {
            throw new NotImplementedException();
        }

        public async Task AddNewMovieAsync(NewMovieVm data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Disc = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageURL,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    Movieid = newMovie.id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }


        public async Task<NewMovieDropdown> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdown()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

    }
}
