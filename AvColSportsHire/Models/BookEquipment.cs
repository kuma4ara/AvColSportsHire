using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvColSportsHire.Models
{
    public class BookEquipment
    {
        [Required]
        public int BookEquipId { get; set; }
        [ForeignKey("BookingId")]
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        [ForeignKey("EquipmentId")]
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        [Display(Name = "Quantity Available")]
        public int QuantityBooked { get; set; }
    }
}
