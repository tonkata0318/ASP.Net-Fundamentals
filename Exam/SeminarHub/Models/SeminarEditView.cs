using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Models
{
    public class SeminarEditView
    {
        [Required]
        [StringLength(topicmaxlength, MinimumLength = topicminlength, ErrorMessage = "Topic name must be between 3 and 100")]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(lecturemaxlength, MinimumLength = lectureminlength, ErrorMessage = "Lecturer name must be between 5 and 60")]
        public string Lecturer { get; set; } = null!;

        [Required]
        [StringLength(detailsmaxlength, MinimumLength = detailseminlength, ErrorMessage = "Details length must be between 10 and 500")]
        public string Details { get; set; } = null!;

        [Required]
        public string DateAndTime { get; set; } = null!;

        [Required]
        [Range(detailseminlength,durationMaxLength,ErrorMessage ="Duration must be between 10 and 180")]
        public int Duration { get; set; }

        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
            = new List<CategoryViewModel>();
    }
}
