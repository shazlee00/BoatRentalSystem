using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace BoatRentalSystem.Infrastructure
{
    public class ReservationAdditionConfiguration : IEntityTypeConfiguration<ReservationAddition>
    {
        public void Configure(EntityTypeBuilder<ReservationAddition> builder)
        {
            builder.HasKey(x=> x.ReservationAdditionId);

           
        }
    }
}