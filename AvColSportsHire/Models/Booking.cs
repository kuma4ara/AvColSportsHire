using AvColSportsHire.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvColSportsHire.Models
{
    [Index(nameof(BookingReference), IsUnique = true)]
    public class Booking
    {
        [Required]
        public int BookingId { get; set; }

        // This ForeignKey attribute specifies that the UserId property is a foreign key referencing the primary key of the related SportsHireUser entity. It helps Entity Framework understand the relationship between the Booking and SportsHireUser entities, allowing for proper navigation and data integrity.
        [ForeignKey("UserId")]
        [Display(Name = "App User")]
        public string UserId { get; set; }

        // BookingReference is an alphanumeric code that uniquely identifies a booking. It must be exactly 6 characters long, ensuring that each booking can be easily referenced and tracked within the system.
        [MinLength(12)]
        [MaxLength(12)]
        public string? BookingReference { get; set; }

        //Date field is allocated the DataType annotation to allow only the date to be selected.
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookingDate { get; set; }

        //Time field is allocated the DataType annotation to allow only the time to be selected.
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0: HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        //Time field is allocated the DataType annotation to allow only the time to be selected
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0: HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        // EventType is an enumeration that categorizes the type of event associated with the booking. It includes predefined values such as Training, Match, Performance, and Other, allowing for consistent classification of bookings based on their purpose or nature.
        public enum EventType
        {
            Training,
            Match,
            Performance,
            Other
        }

        // This section provides detail for the Other event type, allowing users to specify a custom description when the EventType is set to Other. It is required and has a maximum length of 200 characters, ensuring that users provide sufficient information about the nature of the event while maintaining data integrity.
        [Required]
        [MaxLength(200)]
        [Display(Name = "Other Event")]
        public string? OtherEventTypeDescription { get; set; }

        // BookingStatus is an enumeration that represents the current status of a booking. It includes values such as Pending, Confirmed, Cancelled, Completed, and Rescheduled, allowing for clear tracking of the booking's lifecycle and facilitating effective management of bookings within the system.
        public enum BookingStatus
        {
            Pending,
            Confirmed,
            Completed,
            Rescheduled,
            Cancelled
        }

        //This section represents a facility as a foreign key for this specific table, the facility must have a value as per the required validation attribute.
        [Required(ErrorMessage = "Select a Facility")]
        [Display(Name = "Facility")]
        public int FacilityId { get; set; }

        // this field is allocated the DataType annotation to allow only the date and time to be selected, it is required and will automatically be set to the current date and time when a new booking is created, providing a timestamp for when the booking was made.
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // This section represents the total number of participants for a booking, it is required and must be between 1 and 1500, ensuring that the number of participants is reasonable and within the capacity limits of the facilities being booked.
        [Required(ErrorMessage = "State total number of Participants")]
        [Range(1, 1500)]
        [Display(Name = "Total Participants")]
        public int TotalParticiants { get; set; }

        //Navigation properties
        public EventType? Event { get; set; }
        public BookingStatus? Status { get; set; }
        public Facilities? Facilities { get; set; }
        public SportsHireUser? SportsHireUser { get; set; }

        public ICollection <BookingHistory>? History { get; set; }


    }
}
