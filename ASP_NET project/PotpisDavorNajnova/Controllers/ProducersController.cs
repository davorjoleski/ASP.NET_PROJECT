using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PotpisDavorNajnova.Data;
using PotpisDavorNajnova.Models;

namespace PotpisDavorNajnova.Controllers
{
    public class ProducersController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProducersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public  async  Task<IActionResult> Index()
        {
            var allproducers = await _context.Producers.ToListAsync();
            return View(allproducers);
        }


        [AllowAnonymous] //Get:Producer?deatila/1
        public async Task<IActionResult> Details(int id)
        {
            var producerdetails = await _context.Producers.FirstOrDefaultAsync(m => m.id == id);
            if (producerdetails == null) return View("NotFound");
            return View(producerdetails);
        }



        public async Task<IActionResult> Edit(int id)
        {
            var producerdetails = await _context.Producers.FirstOrDefaultAsync(m => m.id == id);

            if (producerdetails == null) return View("NotFound");
            return View(producerdetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("id,FullName,ProfPicUrl,Bio")] Producer producer)
        {
            if (!string.IsNullOrWhiteSpace(producer.FullName)){
                _context.Update(producer);
                await _context.SaveChangesAsync();
               

            }

            return RedirectToAction(nameof(Index));


        }

     
        public async Task<IActionResult> Delete(int id)
        {
            var producerdetails = await _context.Producers.FirstOrDefaultAsync(m => m.id == id);
            if (producerdetails == null) return View("NotFound");
            return View(producerdetails);
        }



        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id) 
        {
            var producerdetails = await _context.Producers.FirstOrDefaultAsync(m => m.id == id);
            if (producerdetails == null) return View("NotFound");

            _context.Producers.Remove(producerdetails);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }
    }
}
 