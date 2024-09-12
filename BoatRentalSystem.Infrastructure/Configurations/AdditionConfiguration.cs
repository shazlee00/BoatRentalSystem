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

            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            
            builder.HasOne(x=>x.Owner).WithMany(x=>x.Additions).HasForeignKey(x=>x.OwnerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}