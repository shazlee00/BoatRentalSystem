using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoatRentalSystem.Infrastructure
{
    internal class AdditionConfiguration : IEntityTypeConfiguration<Addition>
    {
        public AdditionConfiguration() { }  
    public void Configure(EntityTypeBuilder<Addition> builder)
        {
            builder.ToTable("Additions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}