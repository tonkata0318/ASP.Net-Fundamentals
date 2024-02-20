using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        public int Id { get; init; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(DataConstants.Board.BoardMaxName)]
        public string Name { get; init; } = null!;

        public IEnumerable<Task> Tasks { get; set;} = new List<Task>();
    }
}
