using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoatRentalSystem.Infrastructure
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .ToTable("Countries");

            builder
                .HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

        }
    }
}