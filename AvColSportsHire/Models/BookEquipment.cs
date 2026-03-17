using System.ComponentModel.DataAnnotations;

namespace AvColSportsHire.Models
{
    public class BookEquipment
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        [Display(Name = "Quantity Available")]
        public int QuantityBooked { get; set; }
    }
}
