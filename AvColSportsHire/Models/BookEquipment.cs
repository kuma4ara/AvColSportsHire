using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvColSportsHire.Models
{
    public class BookEquipment
    {
        [Required]
        public int BookEquipId { get; set; }
        public int BookingId { get; set; }
        public int EquipmentId { get; set; }
        [Display(Name = "Quantity Available")]
        public int QuantityBooked { get; set; }

        //Navigation properties
        public Booking Booking { get; set; }
        public Equipment Equipment { get; set; }
    }
}
