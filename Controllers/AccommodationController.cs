using Microsoft.AspNetCore.Mvc;
using TripLog_App.Models.DataAccess;
using TripLog_App.Models.DomainModels;

namespace TripLog_App.Controllers
{
    public class AccommodationController : Controller
    {
        private Repository<Accommodation> data { get; set; }
        public AccommodationController(TripLogContext ctx)
        {
            data = new Repository<Accommodation>(ctx);
        }

        public IActionResult Index()
        {
            var accom = data.List(new Queryoptions<Accommodation>()
            {
                Where = a => a.AccommodationId > 0,
                OrderBy = a => a.AccommodationName
            });
            return View(accom);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Accommodation());
        }
        [HttpPost]
        public IActionResult Add(Accommodation model)
        {
            if (ModelState.IsValid)
            {
                data.Insert(model);
                data.Save();
                TempData["message"] = $"{model.AccommodationName} added.";
                return RedirectToAction("Index" );
            }
            else
            {
                return View(model);
            }
        }
    }
}
