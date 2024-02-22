using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TripLog_App.Models.DataAccess;
using TripLog_App.Models.DomainModels;
using TripLog_App.Models.ViewModels;

namespace TripLog_App.Controllers
{
    public class TripController : Controller
    {
        private Repository<Trip> tripData { get; set; }
        private Repository<Destination> destinationaData { get; set; }
        private Repository<Accommodation> accomoadtionData { get; set; }
        private Repository<Activity> activityData { get; set; }
        public TripController(TripLogContext ctx)
        {
            tripData = new Repository<Trip>(ctx);
            destinationaData = new Repository<Destination>(ctx);
            accomoadtionData = new Repository<Accommodation>(ctx);
            activityData = new Repository<Activity>(ctx);

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add(string id = "")
        {
            var vm = new TripViewModel();
            if (id.ToLower() == "page1")
            {
                vm.PageNumber = 1;

                vm.Destinations = destinationaData.List(new Queryoptions<Destination>()
                {
                    OrderBy = d => d.DestName
                });
                vm.Accommodations = accomoadtionData.List(new Queryoptions<Accommodation>()
                {
                    OrderBy = d => d.AccommodationName
                });

                vm.Activities = activityData.List(new Queryoptions<Activity>()
                {
                    OrderBy = d => d.ActivityName
                });


                return View("Add1", vm);
            }
            else if (id.ToLower() == "page2")
            {
                vm.PageNumber = 2;

                int destId = (int)TempData.Peek("DestinationID")!;
                vm.Trip.Destination = destinationaData.Get(destId)!;

                //Get Data for Select List
                vm.Activities = activityData.List(new Queryoptions<Activity>()
                {
                    OrderBy = d => d.ActivityName
                });
                return View("Add1", vm);
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
