using AvColSportsHire.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace AvColSportsHire.Models
{
    public class Organization
    {
        public int? OrganizationId { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Org Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        public string Contact_Email { get; set; }
        [Required]
        [StringLength(20)]
        public string? Contact_Phone { get; set; }
        [Required]
        [StringLength(255)]
        public bool IsInternal { get; set; }
        public bool IsActive { get; set; }

        //Navigation properties
        public ICollection<Customer> Customers { get; set; }

    }
}
