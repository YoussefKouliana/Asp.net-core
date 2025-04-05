using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GolfClub.Models;
using System;

namespace GolfClub.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure primary keys
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => pc.CategoryId);

            modelBuilder.Entity<ProductReview>()
                .HasKey(pr => pr.ReviewId);

            modelBuilder.Entity<ForumPost>()
                .HasKey(fp => fp.PostId);

            modelBuilder.Entity<BlogPost>()
                .HasKey(bp => bp.PostId);

            modelBuilder.Entity<Booking>()
                .HasKey(b => b.BookingId);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => oi.OrderItemId);

            modelBuilder.Entity<PaymentDetail>()
                .HasKey(pd => pd.PaymentId);

            // Configure relationships

            // User - Booking (One-to-Many)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            // User - ForumPost (One-to-Many)
            modelBuilder.Entity<ForumPost>()
                .HasOne(fp => fp.User)
                .WithMany(u => u.ForumPosts)
                .HasForeignKey(fp => fp.UserId);

            // User - ProductReview (One-to-Many)
            modelBuilder.Entity<ProductReview>()
                .HasOne(pr => pr.User)
                .WithMany(u => u.ProductReviews)
                .HasForeignKey(pr => pr.UserId);

            // Product - ProductReview (One-to-Many)
            modelBuilder.Entity<ProductReview>()
                .HasOne(pr => pr.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(pr => pr.ProductId);

            // ProductCategory - Product (One-to-Many)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.CategoryId);

            // BlogPost - User (Many-to-One)
            modelBuilder.Entity<BlogPost>()
                .HasOne(bp => bp.Author)
                .WithMany(u => u.BlogPosts)
                .HasForeignKey(bp => bp.AuthorId);

            // User - Order (One-to-Many)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            // Order - OrderItem (One-to-Many)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            // Product - OrderItem (One-to-Many)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            // Order - PaymentDetail (One-to-One)
            modelBuilder.Entity<PaymentDetail>()
                .HasOne(pd => pd.Order)
                .WithOne(o => o.PaymentDetail)
                .HasForeignKey<PaymentDetail>(pd => pd.OrderId);

        }
    }
}