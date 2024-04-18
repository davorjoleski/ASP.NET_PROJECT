using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PotpisDavorNajnova.Data;

namespace PotpisDavorNajnova.Controllers
{
    public class CinemasController : Controller
    {


        private readonly ApplicationDbContext _context;

        public CinemasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allcinemas = await _context.Cinemas.ToListAsync();
            return View(allcinemas);
        }


        [AllowAnonymous] //Get:CInemas?deatila/1
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _context.Cinemas.FirstOrDefaultAsync(m=> m.id ==id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }
    }
}
