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
        public virtual DbSet<LocationType> LocationType { get; set; }
        public virtual DbSet<AssociateLocation> AssociateLocation { get; set; }
        public virtual DbSet<ResourceLocation> ResourceLocation { get; set; }
        public virtual DbSet<VentureLocation> VentureLocation { get; set; }
        //public DbSet<GeoArea> GeoArea { get; set; }
        public DbSet<GeoDistance> GeoDistance { get; set; }
        //public DbSet<GeoLocation> GeoLocation { get; set; }
        public DbSet<LatLong> LatLong { get; set; }
        //public DbSet<Line> Line { get; set; }
        //public DbSet<Coordinate> Coordinate { get; set; }
        //public DbSet<Polygon> Polygon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"Server=tcp:goodtocodestack.database.windows.net,1433;Initial Catalog=StackData;Persist Security Info=False;User ID=LocalAdmin;Password=1202cc89-cb6f-453a-ac7e-550b3b5d2d0c;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                optionsBuilder.UseSqlServer(connectionString, 
                    x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "Locality");

                entity.HasIndex(e => e.LocationKey)
                    .IsUnique();

                entity.Property(e => e.LocationDescription)
                    .HasMaxLength(2000);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LocationArea>(entity =>
            {
                entity.ToTable("LocationArea", "Locality");

                entity.HasIndex(e => e.LocationAreaKey)
                    .HasName("IX_LocationArea_Key")
                    .IsUnique();

                entity.HasIndex(e => e.LocationKey)
                    .HasName("IX_LocationArea_LocationId");

                entity.HasIndex(e => new { e.LocationKey, e.PolygonKey })
                    .HasName("IX_LocationArea_All")
                    .IsUnique();
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.ToTable("LocationType", "Locality");

                entity.HasIndex(e => e.LocationTypeKey)
                    .HasName("IX_LocationType_Key")
                    .IsUnique();

                entity.Property(e => e.LocationTypeDescription)
                    .HasMaxLength(250);

                entity.Property(e => e.LocationTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AssociateLocation>(entity =>
            {
                entity.ToTable("AssociateLocation", "Locality");

                entity.HasIndex(e => new { e.AssociateKey, e.LocationKey })
                    .HasName("IX_AssociateLocation_All")
                    .IsUnique();

            });

            modelBuilder.Entity<ResourceLocation>(entity =>
            {
                entity.ToTable("ResourceLocation", "Locality");

                entity.HasIndex(e => new { e.ResourceKey, e.LocationKey })
                    .HasName("IX_ResourceLocation_All")
                    .IsUnique();

            });

            modelBuilder.Entity<VentureLocation>(entity =>
            {
                entity.ToTable("VentureLocation", "Locality");

                entity.HasIndex(e => e.VentureLocationKey)
                    .HasName("IX_VentureLocation_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.LocationKey })
                    .HasName("IX_VentureLocation_All")
                    .IsUnique();
            });

            //modelBuilder.Entity<GeoArea>(entity =>
            //{
            //    entity.ToTable("GeoArea", "Locality");

            //    entity.HasIndex(e => e.GeoAreaKey)
            //        .HasName("IX_GeoArea_Key")
            //        .IsUnique();

            //    entity.Property(e => e.GeodeticArea).HasColumnType("geometry");
            //});

            modelBuilder.Entity<GeoDistance>(entity =>
            {
                entity.ToTable("GeoDistance", "Locality");

                entity.HasIndex(e => e.GeoDistanceKey)
                    .HasName("IX_GeoDistance_Key")
                    .IsUnique();
            });

            //modelBuilder.Entity<GeoLocation>(entity =>
            //{
            //    entity.ToTable("GeoLocation", "Locality");

            //    entity.HasIndex(e => e.GeoLocationKey)
            //        .HasName("IX_GeoLocation_Key")
            //        .IsUnique();
            //});

            modelBuilder.Entity<LatLong>(entity =>
            {
                entity.ToTable("LatLong", "Locality");

                entity.HasIndex(e => e.LatLongKey)
                    .HasName("IX_LatLong_Key")
                    .IsUnique();
            });

            //modelBuilder.Entity<Line>(entity =>
            //{
            //    entity.ToTable("Line", "Locality");

            //    entity.HasIndex(e => e.LineKey)
            //        .HasName("IX_Line_Key")
            //        .IsUnique();
            //});

            //modelBuilder.Entity<Coordinate>(entity =>
            //{
            //    entity.ToTable("Coordinate", "Locality");

            //    entity.HasIndex(e => e.CoordinateKey)
            //        .HasName("IX_Coordinate_Key")
            //        .IsUnique();
            //});

            //modelBuilder.Entity<Polygon>(entity =>
            //{
            //    entity.ToTable("Polygon", "Locality");

            //    entity.HasIndex(e => e.PolygonKey)
            //        .HasName("IX_Polygon_Key")
            //        .IsUnique();

            //    entity.Property(e => e.PolygonSequence).HasColumnType("geometry");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
