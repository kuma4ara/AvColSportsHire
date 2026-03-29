using AvColSportsHire.Areas.Identity.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AvColSportsHire.Models
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }

        [Required, RegularExpression(@"^[A-Z][a-zA-Z0-9 ]*$", ErrorMessage = "Organization name must start with a capital letter and only contain letters, no special characters.")]
        [MaxLength(150)]
        [Display(Name = "Organization Name")]
        public string OrgName { get; set; }

        [Required]
        [MaxLength(150)]
        public string Contact_Email { get; set; }

        [MaxLength(20)]
        public string? Contact_Phone { get; set; }

        [Required(ErrorMessage = "State if your Organization is an AvCol team")]
        [DisplayName("Is it an AvCol Team")]
        public bool IsInternal { get; set; }

        [Required(ErrorMessage = "State if your Organization is still active")]
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        //Navigation properties
        public ICollection<SportsHireUser>? AppUser { get; set; }

    }
}
