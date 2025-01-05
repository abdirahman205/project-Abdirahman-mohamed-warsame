using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_asp.net.Models
{
    public class ParkingHistory
    {
        [Key]
        public int history_id { get; set; }
        [ForeignKey("ParkingSpots")]
        public int spot_id { get; set; }
        public ParkingSpots? spot { get; set; }
        [ForeignKey("Reservations")]
        public int reservation_id { get;set; }
        public Reservations? Reservations { get; set; }
        public DateTime entry_time { get; set; }
        public DateTime exit_time { get; set; }

       
      
       

    }
}
