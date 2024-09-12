using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BoatRentalSystem.Infrastructure.Configurations
{
    public class BoatBookingConfiguration : IEntityTypeConfiguration<BoatBooking>
    {
        public void Configure(EntityTypeBuilder<BoatBooking> builder)
        {
            builder
     .HasMany(b => b.BookingAdditions)
     .WithOne(ba => ba.BoatBooking)
     .HasForeignKey(ba => ba.BoatBookingId);

            builder
                .HasOne(b => b.Customer)
                .WithMany(c => c.BoatBookings)
                .HasForeignKey(b => b.CustomerId);

            builder
                .HasOne(b => b.Boat)
                .WithMany(bt => bt.BoatBookings)
                .HasForeignKey(b => b.BoatId);
        }
    }
}