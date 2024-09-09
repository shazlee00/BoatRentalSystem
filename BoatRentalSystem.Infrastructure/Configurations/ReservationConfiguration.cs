using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoatRentalSystem.Infrastructure.Configurations
{
    internal class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.ReservationId);

         
            builder.Property(r => r.NumberOfPeople)
                   .IsRequired();

     

            builder.Property(r => r.ReservationDate)
                   .IsRequired();

            // Set nullable CanceledAt
            builder.Property(r => r.CanceledAt)
                   .IsRequired(false);

 

            // Set nullable UpdatedAt
            builder.Property(r => r.UpdatedAt)
                   .IsRequired(false);

            // Relationships
            builder.HasOne(r => r.Customer)
                   .WithMany(c => c.Reservations)
                   .HasForeignKey(r => r.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);  // Restrict delete to avoid cascading

            builder.HasOne(r => r.Trip)
                   .WithMany(t => t.Reservations)
                   .HasForeignKey(r => r.TripId)
                   .OnDelete(DeleteBehavior.Restrict);  // Restrict delete to avoid cascading

         

            // Configure many-to-many relationship with Additions through ReservationAdditions
            builder.HasMany(r => r.Additions)
                   .WithMany(ra => ra.Reservations)
                   .UsingEntity<ReservationAddition>(
                       j => j
                           .HasOne(ra => ra.Addition)
                           .WithMany(a => a.ReservationAdditions)
                           .HasForeignKey(ra => ra.AdditionId),
                       j => j
                           .HasOne(ra => ra.Reservation)
                           .WithMany(r => r.ReservationAdditions)
                           .HasForeignKey(ra => ra.ReservationId),
                       j =>
                       {
                           j.HasKey(ra => new { ra.AdditionId, ra.ReservationId });
                           j.ToTable("ReservationAdditions");
                       });
                 



 








        }
    }
}