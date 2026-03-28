using AvColSportsHire.Areas.Identity.Data;
using AvColSportsHire.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AvColSportsHire.Areas.Identity.Data;

public class SportsHireContext : IdentityDbContext<SportsHireUser>
{

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Equipment> Equipments { get; set; }

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

        modelBuilder.Entity<Customer>()
         .HasKey(be => be.CustomerId);

        modelBuilder.Entity<Staff>()
         .HasKey(be => be.StaffId);


        modelBuilder.Entity<SportsHireUser>()
            .HasOne(u => u.Customer)
            .WithOne(c => c.User)
            .HasForeignKey<Customer>(c => c.UserId);

        modelBuilder.Entity<SportsHireUser>()
           .HasOne(u => u.Staff)
           .WithOne(c => c.User)
           .HasForeignKey<Staff>(c => c.UserId);

        base.OnModelCreating(modelBuilder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.Property(e => e.UserId)
                .HasColumnType("nvarchar(450)")
                .IsRequired();

            entity.HasOne(d => d.User)
                .WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.UserId);
        });
        
        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId);

            entity.Property(e => e.UserId)
                .HasColumnType("nvarchar(450)")
                .IsRequired();

            entity.HasOne(d => d.User)
                .WithOne(p => p.Staff)
                .HasForeignKey<Staff>(d => d.UserId);
        });

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Staff)
            .WithMany(s => s.Bookings)             
            .HasForeignKey(b => b.StaffId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Customer)
            .WithMany(c => c.Bookings)
            .HasForeignKey(b => b.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BookingHistory>()
        .HasOne(bh => bh.Booking)
        .WithMany(b => b.History)
        .HasForeignKey(bh => bh.BookingId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BookingHistory>()
            .HasOne(bh => bh.Staff)
            .WithMany()
            .HasForeignKey(bh => bh.ChangedByStaffId)
            .OnDelete(DeleteBehavior.Restrict); 
    }

public DbSet<AvColSportsHire.Models.BookEquipment> BookEquipment { get; set; } = default!;

public DbSet<AvColSportsHire.Models.Booking> Booking { get; set; } = default!;

public DbSet<AvColSportsHire.Models.BookingHistory> BookingHistory { get; set; } = default!;

public DbSet<AvColSportsHire.Models.Customer> Customer { get; set; } = default!;

public DbSet<AvColSportsHire.Models.Equipment> Equipment { get; set; } = default!;

public DbSet<AvColSportsHire.Models.Location> Location { get; set; } = default!;

public DbSet<AvColSportsHire.Models.Organization> Organization { get; set; } = default!;

public DbSet<AvColSportsHire.Models.Payments> Payments { get; set; } = default!;

public DbSet<AvColSportsHire.Models.Staff> Staff { get; set; } = default!;
}
