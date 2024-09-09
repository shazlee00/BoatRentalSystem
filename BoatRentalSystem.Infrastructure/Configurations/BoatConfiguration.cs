using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoatRentalSystem.Infrastructure.Configurations
{
    internal class BoatConfiguration : IEntityTypeConfiguration<Boat>
    {
        public void Configure(EntityTypeBuilder<Boat> builder)
        {
            builder.ToTable("Boats");

            builder.HasKey(b => b.BoatId);


            builder.Property(b => b.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(b => b.Description)
                  .HasMaxLength(500);

            builder.Property(b => b.Capacity)
                  .IsRequired();



            builder.Property(b => b.UpdatedAt)
                        .IsRequired(false);

            // Relationships
            builder.HasOne(b => b.Owner)
                  .WithMany(o => o.Boats)
                  .HasForeignKey(b => b.OwnerId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b => b.Trips)
                  .WithOne(t => t.Boat)
                  .HasForeignKey(t => t.BoatId)
                  .OnDelete(DeleteBehavior.Cascade);






        }
    }
}