using Microsoft.AspNetCore.Mvc;

namespace PotpisDavorNajnova.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
