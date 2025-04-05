using System;
using System.ComponentModel.DataAnnotations;

namespace GolfClub.Models
{
    public class BlogPost
    {
        public int PostId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        // Navigation property
        public virtual ApplicationUser Author { get; set; }
    }
}