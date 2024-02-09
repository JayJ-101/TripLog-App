using TripLog_App.Models.DomainModels;

namespace TripLog_App.Models.ViewModels
{
    public class TripViewModel
    {
        public Trip Trip { get; set; } = new Trip();
        public int PageNumber { get; set; }
        public int[] SelectedActivities { get; set; } = Array.Empty<int>();
        public IEnumerable<Destination> Destinations { get; set; } =
            new List<Destination>();
        public IEnumerable<Accommodation> Accommodations { get; set; } =
            new List<Accommodation>();
        public IEnumerable<Activity> Activities { get; set; } = 
            new List<Activity>();

    }
}
