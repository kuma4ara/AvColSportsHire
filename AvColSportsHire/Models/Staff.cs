using AvColSportsHire.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvColSportsHire.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        [MaxLength(450)]
        [Column(TypeName = "nvarchar(450)")]
        public string UserId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        [StringLength(20)]
        public string? Phone { get; set; }
        public enum Role
        {
            Admin,
            Teacher,
            Coach,
            SportsManager,
        }
        [Required]
        [StringLength(255)]
        public bool IsActive { get; set; }

        //Navigation properties
        [ForeignKey("UserId")]
        public SportsHireUser User { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<BookingHistory> BookingHistories { get; set; }

    }
}

