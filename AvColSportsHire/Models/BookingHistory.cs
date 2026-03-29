using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvColSportsHire.Models
{
    public class BookingHistory
    {
        [Key]
        public int HistoryId { get; set; }

        // This ForeignKey attribute specifies that the BookingId property is a foreign key referencing the primary key of the related Booking entity.
        [Required]
        [ForeignKey("BookingId")]
        public int BookingId { get; set; }

        //DateTime field is allocated the DataType annotation to both date and time of old booking to be set..
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime OldStartDateTime { get; set; }

        //DateTime field is allocated the DataType annotation to both date and time of old booking to be set.
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime OldEndDateTime { get; set; }

        //Reason for change (e.g., "Rescheduled by user", "Cancelled by staff", etc.)
        [MaxLength(200)]
        public string Reason { get; set; }

        // this field is allocated the DataType annotation to allow only the date and time to be selected, it is required and will automatically be set to the current date and time when a new booking is created, providing a timestamp for when the booking was changed.
        [Required]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime? ChangedAt { get; set; } = DateTime.Now;

        //Navigation properties
        public Booking? Booking { get; set; }
    }

}



