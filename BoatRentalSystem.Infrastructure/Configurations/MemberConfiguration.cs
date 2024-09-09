using BoatSystem.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatRentalSystem.Core.Entities;

namespace BoatRentalSystem.Infrastructure.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");
            builder.HasKey(c => c.Id);

            builder.HasOne<ApplicationUser>().WithMany().HasForeignKey(m => m.UserId).IsRequired();
        }
    }
}
