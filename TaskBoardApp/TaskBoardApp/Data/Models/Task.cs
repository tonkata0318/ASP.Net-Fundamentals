using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(DataConstants.Task.TaskMaxTitle)]
        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(DataConstants.Task.TaskMaxDescription)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        public Board? Board { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string OwnerId { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;

    }
}
