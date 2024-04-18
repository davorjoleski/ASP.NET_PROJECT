using Microsoft.AspNetCore.Mvc;
using PotpisDavorNajnova.Data.Services;
using PotpisDavorNajnova.Models;

namespace PotpisDavorNajnova.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _service;

        public ActorsController(IActorService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfPicUrl,Bio")] Actor actor)
        {
             
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: ACtors/Details/1

        public async Task<IActionResult> Details (int id)
        {
            var actorDetail = await _service.GetbyidAsync(id);

            if (actorDetail == null) return View("NotFound");
            return View(actorDetail);   
        }


        //Get: ACtors/Edit/1

        public async Task <IActionResult> Edit(int id)
        {
            var actorDetail = await _service.GetbyidAsync(id);

            if (actorDetail == null) return View("NotFound");
            return View(actorDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("id,FullName,ProfPicUrl,Bio")] Actor actor)
        {
        
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }


        //Get: ACtors/Delete/1


        public async Task<IActionResult> Delete(int id)
        {
            var actorDetail = await _service.GetbyidAsync(id);

            if (actorDetail == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetail = await _service.GetbyidAsync(id);
            if (actorDetail == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

    }
}
