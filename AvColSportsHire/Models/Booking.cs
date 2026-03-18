using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvColSportsHire.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        [Required]
        [MinLength(12)]
        [MaxLength(12)]
        public string BookingReference { get; set; }
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime StartDateTime { get; set; }
        public enum EventType
        {
            Training,
            Match,
            Performance,
            Other
        }
        [Required]
        [StringLength(200)]
        [Display(Name = "Other Event")]
        public string? OtherEventTypeDescription { get; set; }
        public enum Status
        {
            Pending,
            Confirmed,
            Cancelled,
            Completed,
            Rescheduled
        }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public int CreatedAt { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Total Participants")]
        public int TotalParticiants { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
        public Payments Payment { get; set; }
    }
}
