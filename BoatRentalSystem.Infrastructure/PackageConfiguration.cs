using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoatRentalSystem.Infrastructure
{
    internal class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public PackageConfiguration() { }

        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder
                .ToTable("Packages");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}