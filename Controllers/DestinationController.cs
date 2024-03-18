using Microsoft.AspNetCore.Mvc;
using TripLog_App.Models.DataAccess;
using TripLog_App.Models.DomainModels;

namespace TripLog_App.Controllers
{
    public class DestinationController : Controller
    {
        private Repository<Destination> data { get; set; }
        public DestinationController(TripLogContext ctx)
        {
            data = new Repository<Destination>(ctx);
        }
        public IActionResult Index()
        {
            var dest = data.List(new Queryoptions<Destination>()
            {
                Where = a => a.DestinationID > 0,
                OrderBy = a => a.DestName
            });
            return View(dest);
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Destination());
        }
        [HttpPost]
        public IActionResult Add(Destination model)
        {
            if (ModelState.IsValid)
            {
                data.Insert(model);
                data.Save();
                TempData["message"] = $"{model.DestName} added.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var dest = data.Get(id);
            data.Delete(dest);
            data.Save();
            TempData["message"] = $"{dest.DestName} has been deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
