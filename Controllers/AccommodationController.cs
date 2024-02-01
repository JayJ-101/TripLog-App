using Microsoft.AspNetCore.Mvc;

namespace TripLog_App.Controllers
{
    public class AccommodationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
