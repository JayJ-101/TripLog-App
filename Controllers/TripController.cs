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

                int destId = (int)TempData.Peek("DestinationId")!;
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
        [HttpPost]
        public IActionResult Add(TripViewModel vm)
        {
            if (vm.PageNumber == 1)
            {
                if (ModelState.IsValid)
                {
                    TempData["DestinationId"] = vm.Trip.DestinationId;
                    TempData["AccommodaiondD"] = vm.Trip.AccommodationId;
                    TempData["StartDate"] = vm.Trip.StartDate;
                    TempData["EndDate"] = vm.Trip.EndDate;
                    return RedirectToAction("Add", new { id = "Page2" });
                }
                else
                {
                    //invalid Data Validation
                    vm.Destinations = destinationaData.List(new QueryOptions<Destination>
                    {
                        OrderBy = d => d.Name
                    });
                    vm.Accommodations = accomoadtionData.List(new QueryOptions<Accommodation>
                    {
                        OrderBy = a => a.AccommodationName
                    });
                    return View("Add1", vm);
                }

                
            }
            else if(vm.PageNumber == 2)
            {
                vm.Trip.DestinationId = (int)TempData["DestinationId"]!;
                vm.Trip.AccommodationId = (int)TempData["AccommodaiondD"]!;
                vm.Trip.StartDate = (DateTime)TempData["StartDate"]!;
                vm.Trip.EndDate = (DateTime)TempData["EndDate"]!;

                foreach (int id in vm.SelectedActivities)
                {
                    var activity = activityData.Get(id)!;
                    if (activity != null)
                    {
                        vm.Trip.Activities.Add(activity);
                    }
                }
                tripData.Insert(vm.Trip);
                tripData.Save();
                //get destination for notification message
                var dest = destinationaData.Get(vm.Trip.DestinationId);
                TempData["Message"] = $"Trip To {dest?.Name} added.";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
