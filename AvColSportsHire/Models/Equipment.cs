using AvColSportsHire.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace AvColSportsHire.Models
{
    public class Equipment
    {
        public int? EquipmentId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Equipment Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        [MinLength(0)]
        [Display(Name = "Quantity Available")]
        public int QuantityAvailable { get; set; }
        public enum Condition
        {
            Availiable,
            Booked,
            Damaged,
            Maintanence
        }



    }
}   
        
    

   
