using Microsoft.EntityFrameworkCore;
using TripLog_App.Models.DataAccess.Configuration;
using TripLog_App.Models.DomainModels;

namespace TripLog_App.Models.DataAccess
{
    public class TripLogContext:DbContext
    {
        public TripLogContext(DbContextOptions<TripLogContext> options) : base(options) { }

        public DbSet<Accommodation> Accommodations { get; set; } = null!;
        public DbSet<Destination> Destination { get; set; } = null!;
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<Trip> Trips { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new TripConfig());
        }

    }
    
}
