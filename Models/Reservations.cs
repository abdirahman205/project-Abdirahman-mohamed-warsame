using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_asp.net.Models
{
    public class Reservations
    {
        [Key]
        public int reservation_id {  get; set; }
    
        [ForeignKey("ParkingSpots")]
        public int spot_id { get;set;}
        public ParkingSpots? parkingSpots { get; set; }
        public DateTime start_time { get;set; }
        public DateTime end_time { get; set; }

       

      
        
    }
}
