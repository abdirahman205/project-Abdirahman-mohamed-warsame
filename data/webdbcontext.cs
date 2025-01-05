using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using project_asp.net.Models;

namespace project_asp.net.data
{
    public class webDbcontext : IdentityDbContext<Users>
    {
        public webDbcontext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Payment> payment { get; set; }
        public DbSet<ParkingHistory> ParkingHistory { get; set; }
        public DbSet<ParkingSpots> ParkingSpots { get; set; }



    }
}
