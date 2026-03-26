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
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime EndDateTime { get; set; }
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
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public int LocationId { get; set; }
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Total Participants")]
        public int TotalParticiants { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        //Navigation properties
        public Location Location { get; set; }
        public Staff Staff { get; set; }
        public Customer Customer { get; set; }

        public ICollection <BookingHistory> BookingHistories { get; set; }
        public ICollection<BookEquipment> BookEquipments { get; set; }
        public ICollection<Payments> Payments { get; set; }


    }
}
