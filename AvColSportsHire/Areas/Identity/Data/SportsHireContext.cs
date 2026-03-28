using AvColSportsHire.Areas.Identity.Data;
using AvColSportsHire.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AvColSportsHire.Areas.Identity.Data;

public class SportsHireContext : IdentityDbContext<SportsHireUser>
{
    public SportsHireContext(DbContextOptions<SportsHireContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookEquipment>()
            .HasKey(be => be.BookEquipId);

        modelBuilder.Entity<BookingHistory>()
           .HasKey(be => be.HistoryId);

        modelBuilder.Entity<Payments>()
          .HasKey(be => be.PaymentId);

        base.OnModelCreating(modelBuilder); 
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<AvColSportsHire.Models.BookEquipment> BookEquipment { get; set; } = default!;

public DbSet<AvColSportsHire.Models.Booking> Booking { get; set; } = default!;

public DbSet<AvColSportsHire.Models.BookingHistory> BookingHistory { get; set; } = default!;

public DbSet<AvColSportsHire.Models.Equipment> Equipment { get; set; } = default!;

public DbSet<AvColSportsHire.Models.Location> Location { get; set; } = default!;

public DbSet<AvColSportsHire.Models.Organization> Organization { get; set; } = default!;

public DbSet<AvColSportsHire.Models.Payments> Payments { get; set; } = default!;
}
