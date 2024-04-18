using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PotpisDavorNajnova.Data;
using PotpisDavorNajnova.Data.Services;
using PotpisDavorNajnova.Models;

namespace PotpisDavorNajnova.Controllers
{
    public class MoviesController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IMovieService _service;


        public MoviesController(ApplicationDbContext context,IMovieService service)
        {
            _service = service;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _context.Movies.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();
            return View(allMovies);
        }

        [AllowAnonymous]

        public async Task<IActionResult> Details(int id) { 

    
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.id == id);

            return View(movieDetails);
        
    }
    


    [HttpGet]
        public async Task<IActionResult> Filter(string searchTerm, int id)
        {
            // Your search logic goes here
            // You can use searchTerm to filter movies from your database

            var searchResults = await _context.Movies
             .Where(m => m.Name.Contains(searchTerm) || m.Disc.Contains(searchTerm))
                .ToListAsync();
            if (string.IsNullOrWhiteSpace(searchTerm) || (id == null))
            {

                return Content("Please fulfill the search bar with your request");

            }

            ViewBag.SearchTerm = searchTerm;
            ViewBag.Id = id;
            return View(searchResults);
        }




        //create movie

        public async Task<IActionResult> Create()
        {

            var response = new NewMovieDropdown()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };
            ViewBag.Cinemas = new SelectList(response.Cinemas, "id", "FullName");
            ViewBag.Producers = new SelectList(response.Producers, "id", "FullName");
            ViewBag.Actors = new SelectList(response.Actors, "id", "FullName");
            return View();


        }

        //Adding create with IMOVIESERVIE
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVm movie)
        {
            if (!ModelState.IsValid)
            {
                var moviedropdown = await _service.GetNewMovieDropdownsValues();
                ViewBag.Cinemas = new SelectList(moviedropdown.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(moviedropdown.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(moviedropdown.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
    

