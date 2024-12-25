using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utravs.Task1.Infrastructure.Entities;

namespace Utravs.Task1.Infrastructure.DbContext
{
    public class ApplicationDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("UtravsTask1Db");
            base.OnConfiguring(optionsBuilder);
        }

        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext> // Its Unnecessary but i added it because u asked me about this in interview
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionBuilder.UseInMemoryDatabase("UtravsTask1Db");
                return new ApplicationDbContext(optionBuilder.Options);
            }
        }
    }
}

