using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace AvColSportsHire.Models
{
    public class Facilities
    {
        [Key]
        public int FacilityId { get; set; }

        [Required, RegularExpression(@"^[A-Z][a-zA-Z0-9 ]*$", ErrorMessage = "Facility name must start with a capital letter and only contain letters and numbers, no special characters.")]
        [MinLength(2), MaxLength(150)]
        [Display(Name = "Facility Name")]
        public string Name { get; set; }

        [Required, RegularExpression(@"^[A-Z][a-zA-Z0-9 ]*$", ErrorMessage = "Facility type must start with a capital letter and only contain letters and numbers, no special characters.")]
        [MinLength(2), MaxLength(150)]
        public string Type { get; set; }

        [Required]
        [MinLength(2), MaxLength(200)]
        public string Description { get; set; }

        [Required, RegularExpression(@"^[0-9]{2}\.[0-9]{2}$", ErrorMessage = "All hourly rates must be written as dd.cc format")]
        [Column (TypeName = "decimal(10,2)")]
        [Display(Name = "Hourly Rate (NZD)")]
        public decimal HourlyRate { get; set; }
        public enum ConditionStatus
        {
            Availiable,
            Booked,
            Damaged,
            Maintanence
        }

        //Navigation properties
        public ConditionStatus Condition { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
