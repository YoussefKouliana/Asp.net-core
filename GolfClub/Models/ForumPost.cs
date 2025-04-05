using System;
using System.ComponentModel.DataAnnotations;

namespace GolfClub.Models
{
    public class ForumPost
    {
        public int PostId { get; set; }

        public string UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; } = DateTime.Now;

        // Navigation property
        public virtual ApplicationUser User { get; set; }
    }
}