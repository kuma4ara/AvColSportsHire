using AvColSportsHire.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace AvColSportsHire.Models
{
    public class Customer : SportsHireUser
    {

        public int CustomerId { get; set; }
        public int? OrganizationId { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        [StringLength(20)]
        public string? Phone { get; set; }
        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }

        //Navigation properties
        public Organization Organization { get; set; }
        public ICollection <Booking> Bookings { get; set; }

    }
}
