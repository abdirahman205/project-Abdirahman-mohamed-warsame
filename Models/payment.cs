using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_asp.net.Models
{
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }
        [ForeignKey("Reservations")]
        public int reservation_id { get; set; }
        public Reservations? reservation { get; set; }
        public decimal amount { get; set; }
    
     


       
    }
}
