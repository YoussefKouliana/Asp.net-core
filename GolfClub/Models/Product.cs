using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfClub.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ProductCategory Category { get; set; }
        public virtual ICollection<ProductReview> Reviews { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}