using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace AvColSportsHire.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Location Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [Column (TypeName = "decimal(10,2)")]
        public decimal HourlyRate { get; set; }
        public enum ConditionStatus
        {
            Availiable,
            Booked,
            Damaged,
            Maintanence
        }

        //Navigation properties
        public ICollection<Booking> Bookings { get; set; }
    }
}
