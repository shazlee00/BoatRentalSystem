using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Infrastructure
{
    public class ApplicationDbContext:DbContext
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
        }


    }

   
}
