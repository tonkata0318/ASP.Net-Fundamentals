using Humanizer;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using static Homies.Data.DataConstants;

namespace Homies.Data
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(nameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Event> Events { get; set; }=new List<Event>();
    }

}
