using Gbc_Travel_Group63.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Gbc_Travel_Group63.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}
