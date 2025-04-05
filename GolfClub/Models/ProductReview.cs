using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfClub.Models
{
    public class ProductReview
    {
        public int ReviewId { get; set; }

        public int ProductId { get; set; }

        public string UserId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public string ReviewText { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReviewDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}