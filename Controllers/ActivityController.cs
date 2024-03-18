using Microsoft.AspNetCore.Mvc;
using TripLog_App.Models.DataAccess;
using TripLog_App.Models.DomainModels;

namespace TripLog_App.Controllers
{
    public class ActivityController : Controller
    {
        private Repository<Activity> data { get; set; }
        public ActivityController(TripLogContext ctx)
        {
            data = new Repository<Activity>(ctx);
        }
        
        public IActionResult Index()
        {
            var activity = data.List(new Queryoptions<Activity>()
            {
                Where = a => a.ActivityID > 0,
                OrderBy = a => a.ActivityName
            });
            return View(activity);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Activity());
        }
        [HttpPost]
        public IActionResult Add(Activity model)
        {
            if (ModelState.IsValid)
            {
                data.Insert(model);
                data.Save();
                TempData["message"] = $"{model.ActivityName} added.";
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
            var activity = data.Get(id);
            data.Delete(activity);
            data.Save();
            TempData["message"] = $"{activity.ActivityName} has been deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

