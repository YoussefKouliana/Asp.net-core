using System;
using System.ComponentModel.DataAnnotations;

namespace GolfClub.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime GolfTime { get; set; }

        [Required]
        public int Duration { get; set; } // Duration in minutes

        // Navigation property
        public virtual ApplicationUser User { get; set; }
    }
}