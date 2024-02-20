using ForumApp2024.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp2024.Infrastructure.Data.Models
{
    [Comment("Posts table")]
    public class Post
    {
        [Key]
        [Comment("Post Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstant.TitleMaxLength)]
        [MinLength(ValidationConstant.TitleMinLength)]
        [Comment("Post Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(ValidationConstant.ContentMaxLength)]
        [MinLength(ValidationConstant.ContentMinLength)]
        [Comment("Post Content")]
        public string Content { get; set; } = string.Empty;

    }
}
