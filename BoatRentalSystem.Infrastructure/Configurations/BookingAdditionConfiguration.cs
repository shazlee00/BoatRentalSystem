using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoatRentalSystem.Infrastructure.Configurations
{
    public class BookingAdditionConfiguration : IEntityTypeConfiguration<BookingAddition>
    {
        public void Configure(EntityTypeBuilder<BookingAddition> builder)
        {
            builder.ToTable("BookingAdditions");
            builder.HasKey(x => x.BookingAdditionId);
            builder.HasOne(x => x.BoatBooking).WithMany(x => x.BookingAdditions).HasForeignKey(x => x.BoatBookingId);

        }
    }
}