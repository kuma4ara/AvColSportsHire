using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvColSportsHire.Models
{
    public class Payments
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
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
    }
}
