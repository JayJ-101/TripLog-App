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
            var accommodation = data.List(new Queryoptions<Accommodation>()
            {
                Where = a => a.AccommodationID > 0,
                OrderBy = a => a.AccommodationName
            });
            return View(accommodation);
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
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var accom = data.Get(id);
            data.Delete(accom);
            data.Save();
            TempData["message"] = $"{accom.AccommodationName} has been deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
