using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models
{
    public class SeminarDetailsModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Topic { get; set; } = null!;

        [Required]
        public string DateAndTime { get; set; } = null!;

        [Required]

        public int Duration { get; set; }

        [Required]
        public string Lecturer { get; set; } = null!;

        [Required]
        public string Category { get; set; } = null!;


        [Required]
        public string Details { get; set; } = null!;

        [Required]
        public string Organizer { get; set; } = null!;
    }
}
