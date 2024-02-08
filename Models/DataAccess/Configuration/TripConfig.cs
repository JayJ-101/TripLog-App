using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripLog_App.Models.DomainModels;

namespace TripLog_App.Models.DataAccess.Configuration
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> entity)
        {
            entity.HasOne(t => t.Destination)
                .WithMany(d => d.Trips)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
