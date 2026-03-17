using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvColSportsHire.Models
{
    public class BookingHistory
    {
        public int HistoryId { get; set; }
        public int BookingId { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime OldStartDateTime { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime OldEndDateTime { get; set; }
        [Required]
        [Display(Name = "Change by Staff")]
        public int ChangedByStaffId { get; set; }
        public Staff Staff { get; set; }
        [StringLength(200)]
        public string? Reason { get; set; }
    }
}
