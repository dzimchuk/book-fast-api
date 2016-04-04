using Microsoft.Data.Entity;

namespace BookFast.Data.Models
{
    internal class BookFastContext : DbContext
    {
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facility>()
                        .HasMany(facility => facility.Accommodations)
                        .WithOne(acc => acc.Facility);

            modelBuilder.Entity<Accommodation>()
                        .HasMany(acc => acc.Bookings)
                        .WithOne(booking => booking.Accommodation);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV12;Initial Catalog=BookFast;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}