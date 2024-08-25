using BoatRentalSystem.Core.Entities;
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



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConfiguration());
            modelBuilder.ApplyConfiguration(new AdditionConfiguration());





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
                    Name = "User",
                    NormalizedName = "USER"

                });
            });







        }


    }

   
}
