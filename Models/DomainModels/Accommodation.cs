using System.ComponentModel.DataAnnotations;

namespace TripLog_App.Models.DomainModels
{
    public class Accommodation
    {
        public int AccommodationId { get; set; }

        [Required(ErrorMessage = "Please enter accommodation name.")]
        [Display(Name = "Accomodation Name")]
        public string AccommodationName { get; set; } = string.Empty;

        public string? Phone { get; set; }
        public string? Email { get; set; }

        
    }
}
