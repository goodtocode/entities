using System;
using GoodToCode.Locality.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class LocalityDbContext : DbContext
    {
        public LocalityDbContext()
        {
        }

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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LocationDescription)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Location)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_RecordState");
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.LocationKeyNavigation)
                    .WithMany(p => p.LocationArea)
                    .HasPrincipalKey(p => p.LocationKey)
                    .HasForeignKey(d => d.LocationKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationArea_Location");
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TimeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.LocationKeyNavigation)
                    .WithMany(p => p.LocationTimeRecurring)
                    .HasPrincipalKey(p => p.LocationKey)
                    .HasForeignKey(d => d.LocationKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationTimeRecurring_Location");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.LocationTimeRecurring)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationTimeRecurring_RecordState");

                entity.HasOne(d => d.TimeRecurringKeyNavigation)
                    .WithMany(p => p.LocationTimeRecurring)
                    .HasPrincipalKey(p => p.TimeRecurringKey)
                    .HasForeignKey(d => d.TimeRecurringKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationTimeRecurring_TimeRecurring");

                entity.HasOne(d => d.TimeTypeKeyNavigation)
                    .WithMany(p => p.LocationTimeRecurring)
                    .HasPrincipalKey(p => p.TimeTypeKey)
                    .HasForeignKey(d => d.TimeTypeKey)
                    .HasConstraintName("FK_LocationAvailable_TimeType");
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.ToTable("LocationType", "Entity");

                entity.HasIndex(e => e.LocationTypeKey)
                    .HasName("IX_LocationType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LocationTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LocationTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
