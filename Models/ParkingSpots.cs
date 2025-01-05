using System.ComponentModel.DataAnnotations;

namespace project_asp.net.Models
{
    public class ParkingSpots
    {
        [Key]
        public int spot_id { get; set; }
        public int location { get; set; }
        public decimal price_per_hour { get; set; }
       
    }
}
