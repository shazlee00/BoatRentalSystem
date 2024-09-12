using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Infrastructure.Configurations;
using BoatSystem.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Infrastructure
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Package> Packages { get; set; }
        public DbSet<Addition> Additions { get; set; }

        public DbSet<Owner> Owners { get; set; }
        
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Member> Members { get; set; }


        public DbSet<Boat> Boats { get; set; } 

        public DbSet<Trip> Trips  { get; set; }

        public DbSet<Reservation> Reservations  { get; set; }

        public DbSet<ReservationAddition> ReservationAdditions  { get; set; }

     
        
        public DbSet<BoatBooking> BoatBookings { get; set; }

       public DbSet<BookingAddition> bookingAdditions { get; set; }

        public DbSet<Cancellation> Cancellations { get; set; }

        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConfiguration());
            modelBuilder.ApplyConfiguration(new AdditionConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.ApplyConfiguration(new BoatConfiguration());
            modelBuilder.ApplyConfiguration(new TripConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());




            modelBuilder.ApplyConfiguration(new CancellationConfiguration());
            modelBuilder.ApplyConfiguration(new BoatBookingConfiguration());
            modelBuilder.ApplyConfiguration(new BookingAdditionConfiguration());

            modelBuilder.ApplyConfiguration(new ReservationAdditionConfiguration());

            modelBuilder.Entity<Addition>().HasData(
           new Addition
           {
               Id = 1,
               Name = "Lunch Package",
               OwnerId = 2, 
               Description = "Includes a variety of local dishes for your trip.",
               Price = 15.00,
               CreatedAt = DateTime.Now
           },
           new Addition
           {
               Id = 2,
               Name = "Snorkeling Gear",
               OwnerId = 2, 
               Description = "High-quality snorkeling gear for underwater exploration.",
               Price = 25.00,
               CreatedAt = DateTime.Now
           },
           new Addition
           {
               Id = 3,
               Name = "Fishing Equipment",
               OwnerId = 2, 
               Description = "Full fishing kit for a day of fishing on the boat.",
               Price = 30.00,
               CreatedAt = DateTime.Now
           }
       );


            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.HasData(new IdentityRole
                {
                    Id = "7bdb9275-8cd4-4d86-bea6-bbdb5125e28a",
                    Name = "Admin",
                    NormalizedName = "ADMIN"

                });


                entity.HasData(new IdentityRole
                {
                    Id = "f117b498-2e53-4686-86dc-d3c13072850e",
                    Name = "Member",
                    NormalizedName = "Member"

                });

                entity.HasData(new IdentityRole
                {
                    Id = "936c5f84-e463-49c2-bb6a-93347bbd5103",
                    Name = "owner",
                    NormalizedName = "OWNER"

                });

                entity.HasData(new IdentityRole
                {
                    Id="5a96f68c-c551-45f8-ad00-d4ae56c4afd5",
                    Name = "Customer",
                    NormalizedName="CUSTOMER"
                }

                    );

            });
        }


    }

   
}
