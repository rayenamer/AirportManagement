using Microsoft.EntityFrameworkCore;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Domaine;   // ❌ remove this (wrong namespace)

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        // DbSets
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        // Database Provider
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=AirportManagement.db");
            }
        }

        // Pre-conventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                .HaveColumnType("datetime2");
        }

        // Fluent API Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✔ Inheritance Discriminator
            modelBuilder.Entity<Passenger>()
                .HasDiscriminator<int>("IsTraveller")
                .HasValue<Passenger>(0)
                .HasValue<Traveller>(1)
                .HasValue<Staff>(2);

            // ✔ Ticket Configuration (moved inside OnModelCreating)
            modelBuilder.Entity<Ticket>(builder =>
            {
                // Composite Key
                builder.HasKey(t => new { t.PassengerFk, t.FlightFk, t.NumTicket });

                // Passenger (One Passenger → Many Tickets)
                builder.HasOne(t => t.Passenger)
                       .WithMany(p => p.Tickets)
                       .HasForeignKey(t => t.PassengerFk);

                // Flight (One Flight → Many Tickets)
                builder.HasOne(t => t.Flight)
                       .WithMany(f => f.Tickets)
                       .HasForeignKey(t => t.FlightFk);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
