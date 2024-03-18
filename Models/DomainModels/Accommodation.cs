using System.ComponentModel.DataAnnotations;

namespace TripLog_App.Models.DomainModels
{
    public class Accommodation
    {
        public Accommodation() => Trips = new HashSet<Trip>();

        public int AccommodationID { get; set; }

        [Required(ErrorMessage = "Please enter accommodation name.")]
        [Display(Name = "Accomodation Name")]
        public string AccommodationName { get; set; } = string.Empty;

        public string? Phone { get; set; }
        public string? Email { get; set; }

        public ICollection<Trip> Trips { get; set; }

        public bool HasPhone => !string.IsNullOrEmpty(Phone);
        public bool HasEmail => !string.IsNullOrEmpty(Email);
    }
}
