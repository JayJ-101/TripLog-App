using System.ComponentModel.DataAnnotations;

namespace TripLog_App.Models.DomainModels
{
    public class Activity
    {
        public int ActivityID { get; set; }
        [Required(ErrorMessage = "Please fill activity description.")]
        public string ActivityName { get; set; } = string.Empty;

    }
}
