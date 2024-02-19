using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;
using TripLog_App.Models;
using TripLog_App.Models.DataAccess;
using TripLog_App.Models.DomainModels;

namespace TripLog_App.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Trip> data { get; set; }

        public HomeController(TripLogContext ctx)
        {
            data = new Repository<Trip>(ctx);
        }
        public IActionResult Index()
        {
            var options = new Queryoptions<Trip>()
            {
                Includes = "Destination, Accommodation, Activities",
                OrderBy = t=> t.StartDate!
            };
            var trips = data.List(options);
            return View(trips);
        }

       
        
    }
}