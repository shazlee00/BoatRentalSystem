using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoatRentalSystem.Infrastructure.Configurations
{
    internal class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder
                .ToTable("Trips");
            builder.HasKey(b => b.TripId);


            builder.Property(b => b.Name)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(b => b.Description)
                  .HasMaxLength(500);



            builder.Property(b => b.UpdatedAt)
                        .IsRequired(false);

            // Relationships
            builder.HasOne(b => b.Owner)
                  .WithMany(o => o.Trips)
                  .HasForeignKey(b => b.OwnerId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b => b.Reservations)
                  .WithOne(t => t.Trip)
                  .HasForeignKey(t => t.TripId)
                  .OnDelete(DeleteBehavior.Cascade);


        }
    }
}