using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace TripLog_App.Models.DomainModels
{
    public class Trip
    {
        public Trip() => Activities = new HashSet<Activity>();
        public int TripId { get; set; }
        public int DestinationID { get; set; }
        [ValidateNever]
        public Destination Destination{ get; set; } = null!;

        
        public int AccommodationID { get; set; }
        [ValidateNever]
        public Accommodation Accommodation { get; set; } = null!;


        [Required(ErrorMessage = "Please enter Start date.")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Please enter End date.")]
        public DateTime? EndDate { get; set; } 

        public ICollection<Activity> Activities { get; set; }
    }
}
