using GoodToCode.Locality.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Locality.Infrastructure
{
    public partial class LocalityDbContext : DbContext, ILocalityDbContext
    {
        public LocalityDbContext(DbContextOptions<LocalityDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationArea> LocationArea { get; set; }
        public virtual DbSet<LocationTimeRecurring> LocationTimeRecurring { get; set; }
        public virtual DbSet<LocationType> LocationType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=tcp:goodtocodestack.database.windows.net,1433;Initial Catalog=StackData;Persist Security Info=False;User ID=LocalAdmin;Password=1202cc89-cb6f-453a-ac7e-550b3b5d2d0c;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "Entity");

                entity.HasIndex(e => e.LocationKey)
                    .IsUnique();

                entity.Property(e => e.LocationDescription)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LocationArea>(entity =>
            {
                entity.ToTable("LocationArea", "Entity");

                entity.HasIndex(e => e.LocationAreaKey)
                    .HasName("IX_LocationArea_Key")
                    .IsUnique();

                entity.HasIndex(e => e.LocationKey)
                    .HasName("IX_LocationArea_LocationId");

                entity.HasIndex(e => new { e.LocationKey, e.AreaKey })
                    .HasName("IX_LocationArea_All")
                    .IsUnique();
            });

            modelBuilder.Entity<LocationTimeRecurring>(entity =>
            {
                entity.ToTable("LocationTimeRecurring", "Entity");

                entity.HasIndex(e => e.LocationTimeRecurringKey)
                    .HasName("IX_LocationTimeRecurring_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.LocationKey, e.TimeRecurringKey })
                    .HasName("IX_LocationTimeRecurring_All")
                    .IsUnique();

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.ToTable("LocationType", "Entity");

                entity.HasIndex(e => e.LocationTypeKey)
                    .HasName("IX_LocationType_Key")
                    .IsUnique();

                entity.Property(e => e.LocationTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LocationTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
