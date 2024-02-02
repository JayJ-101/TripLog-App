using Microsoft.EntityFrameworkCore;
using TripLog_App.Models.DomainModels;

namespace TripLog_App.Models.DataAccess
{
    public class TripLogContext:DbContext
    {
        public TripLogContext(DbContextOptions<TripLogContext> options) : base(options) { }

        public DbSet<Accommodation> Accommodations { get; set; } = null!;
        public DbSet<Destination> Destination { get; set; } = null!;

    }
}
