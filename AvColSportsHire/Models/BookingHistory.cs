using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvColSportsHire.Models
{
    public class BookingHistory
    {
        public int HistoryId { get; set; }
        public int BookingId { get; set; }
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime OldStartDateTime { get; set; }
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime OldEndDateTime { get; set; }
        [Required]
        [Display(Name = "Changed By")]
        public int ChangedByStaffId { get; set; }
        [StringLength(200)]
        public string Reason { get; set; }
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime? ChangedAt { get; set; } = DateTime.Now;

        //Navigation properties
        public Booking Booking { get; set; }
        public Staff Staff { get; set; }
    }

}



