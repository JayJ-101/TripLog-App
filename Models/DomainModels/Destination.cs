using System.ComponentModel.DataAnnotations;

namespace TripLog_App.Models.DomainModels
{
    public class Destination
    {

        public int DestinationId { get; set; }
        [Display(Name ="Destination Name")]
        [Required(ErrorMessage ="This field is required.")]
        public string DestName { get; set; } = string.Empty;

    }
}
