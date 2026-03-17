using AvColSportsHire.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace AvColSportsHire.Models
{
    public class Customer : SportsHireUser
    {

        public int CustomerId { get; set; }
        public int? OrganizationId { get; set; }
        public Organization Organization { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string FullName => $"{FirstMidName} {LastName}";
        public string? Phone { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
       
    }
}
