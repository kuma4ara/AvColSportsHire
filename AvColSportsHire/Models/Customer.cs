using AvColSportsHire.Areas.Identity.Data;

namespace AvColSportsHire.Models
{
    public class Customer : SportsHireUser
    {
        public int CustomerId { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Phone { get; set; }

    }
}
