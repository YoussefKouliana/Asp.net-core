using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GolfClub.Models
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        // Navigation property
        public virtual ICollection<Product> Products { get; set; }
    }
}