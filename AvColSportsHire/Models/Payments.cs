using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvColSportsHire.Models
{
    public class Payments
    {
        public int PaymentId { get; set; }
        [ForeignKey("BookingId")]
        public int BookingId { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        [ForeignKey("Amount")]
        public decimal Amount { get; set; }
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime PaymentDateTime { get; set; } = DateTime.Now;
        public enum PaymentMethod
        {
            Card,
            Cash,
            PayPal,
            BankTransfer
        }
       public enum PaymentStatus
        {
            Pending,
            Completed,
            Cancelled,
            Refunded
        }
        [StringLength(150)]
        [Display(Name = "Transaction Reference")]
        public string? TransactionReference { get; set; }

        //Navigation properties
        public Booking Booking { get; set; }
    }
}
