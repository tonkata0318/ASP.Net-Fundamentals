using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(categoryMaxLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}
