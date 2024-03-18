using System.ComponentModel.DataAnnotations;

namespace TripLog_App.Models.DomainModels
{
    public class Destination
    {
        public Destination() => Trips = new HashSet<Trip>();
        public int DestinationID { get; set; }
        [Display(Name ="Destination Name")]
        [Required(ErrorMessage ="This field is required.")]
        public string DestName { get; set; } = string.Empty;

        public ICollection<Trip> Trips { get; set; }
    }
}
