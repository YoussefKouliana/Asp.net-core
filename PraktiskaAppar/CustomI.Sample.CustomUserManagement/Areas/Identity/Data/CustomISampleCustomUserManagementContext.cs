using CustomI.Sample.CustomUserManagement.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomI.Sample.CustomUserManagement.Data;

public class CustomISampleCustomUserManagementContext : IdentityDbContext<ApplicationUser>
{
    public CustomISampleCustomUserManagementContext(DbContextOptions<CustomISampleCustomUserManagementContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    protected void RenameIdentityTables(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("custom_user_management");
        builder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable(name: "users");
        });
        builder.Entity<IdentityRole>(entity =>
        {
            entity.ToTable(name: "roles");
        });
        builder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.ToTable("user_roles");
        });
        builder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.ToTable("user_claims");
        });
        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable("user_logins");
        });
    }
}
