using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BoatRentalSystem.Infrastructure.Configurations
{
    public class CancellationConfiguration : IEntityTypeConfiguration<Cancellation>
    {
        public void Configure(EntityTypeBuilder<Cancellation> builder)
        {
            builder.HasOne(c => c.Customer)
            .WithMany(cu => cu.Cancellations)
             .HasForeignKey(c => c.CustomerId);

           

          
        }
    }
}