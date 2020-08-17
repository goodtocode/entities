using GoodToCode.Chronology.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Chronology.Infrastructure
{
    public partial class ChronologyDbContext : DbContext, IChronologyDbContext
    {
        public ChronologyDbContext(DbContextOptions<ChronologyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<ScheduleSlot> ScheduleSlot { get; set; }
        public virtual DbSet<ScheduleType> ScheduleType { get; set; }
        public virtual DbSet<Slot> Slot { get; set; }
        public virtual DbSet<SlotLocation> SlotLocation { get; set; }
        public virtual DbSet<SlotResource> SlotResource { get; set; }
        public virtual DbSet<SlotTimeRange> SlotTimeRange { get; set; }
        public virtual DbSet<SlotTimeRecurring> SlotTimeRecurring { get; set; }
        public virtual DbSet<AssociateTimeRecurring> AssociateTimeRecurring { get; set; }
        public virtual DbSet<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        public virtual DbSet<VentureTimeRecurring> VentureTimeRecurring { get; set; }
        public virtual DbSet<AssociateSchedule> AssociateSchedule { get; set; }
        public virtual DbSet<ResourceSchedule> ResourceSchedule { get; set; }
        public virtual DbSet<VentureSchedule> VentureSchedule { get; set; }
        public virtual DbSet<TimeCycle> TimeCycle { get; set; }
        public virtual DbSet<TimeRange> TimeRange { get; set; }
        public virtual DbSet<TimeRecurring> TimeRecurring { get; set; }
        public virtual DbSet<TimeType> TimeType { get; set; }

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
            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule", "Entity");

                entity.HasIndex(e => e.ScheduleKey)
                    .IsUnique();

                entity.Property(e => e.ScheduleDescription)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ScheduleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ScheduleSlot>(entity =>
            {
                entity.ToTable("ScheduleSlot", "Entity");

                entity.HasIndex(e => e.ScheduleKey)
                    .HasName("IX_ScheduleSlot_Schedule");

                entity.HasIndex(e => e.ScheduleSlotKey)
                    .HasName("IX_ScheduleSlot_Key")
                    .IsUnique();

                entity.HasIndex(e => e.SlotKey)
                    .HasName("IX_ScheduleSlot_Slot");

                entity.HasIndex(e => new { e.SlotKey, e.ScheduleKey })
                    .HasName("IX_ScheduleSlot_All")
                    .IsUnique();
            });

            modelBuilder.Entity<ScheduleType>(entity =>
            {
                entity.ToTable("ScheduleType", "Entity");

                entity.HasIndex(e => e.ScheduleTypeKey)
                    .HasName("IX_ScheduleType_Key")
                    .IsUnique();

                entity.Property(e => e.ScheduleTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ScheduleTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot", "Entity");

                entity.HasIndex(e => e.SlotKey)
                    .IsUnique();

                entity.Property(e => e.SlotDescription)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.SlotName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SlotLocation>(entity =>
            {
                entity.ToTable("SlotLocation", "Entity");

                entity.HasIndex(e => e.SlotKey)
                    .HasName("IX_SlotLocation_Slot");

                entity.HasIndex(e => e.SlotLocationKey)
                    .HasName("IX_SlotLocation_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.SlotKey, e.LocationKey })
                    .HasName("IX_SlotLocation_All")
                    .IsUnique();
            });

            modelBuilder.Entity<SlotResource>(entity =>
            {
                entity.ToTable("SlotResource", "Entity");

                entity.HasIndex(e => e.ResourceKey)
                    .HasName("IX_SlotResource_Resource");

                entity.HasIndex(e => e.SlotKey)
                    .HasName("IX_SlotResource_Slot");

                entity.HasIndex(e => e.SlotResourceKey)
                    .IsUnique();

                entity.HasIndex(e => new { e.ResourceKey, e.SlotKey })
                    .HasName("IX_SlotResource_All")
                    .IsUnique();
            });

            modelBuilder.Entity<SlotTimeRange>(entity =>
            {
                entity.ToTable("SlotTimeRange", "Entity");

                entity.HasIndex(e => e.SlotKey)
                    .HasName("IX_SlotTimeRange_Slot");

                entity.HasIndex(e => new { e.SlotKey, e.TimeRangeKey })
                    .HasName("IX_SlotTime_All")
                    .IsUnique();
            });

            modelBuilder.Entity<SlotTimeRecurring>(entity =>
            {
                entity.ToTable("SlotTimeRecurring", "Entity");

                entity.HasIndex(e => e.SlotKey)
                    .HasName("IX_SlotTimeRecurring_Slot");

                entity.HasIndex(e => new { e.SlotKey, e.TimeRecurringKey })
                    .HasName("IX_SlotTime_All")
                    .IsUnique();
            });

            modelBuilder.Entity<AssociateTimeRecurring>(entity =>
            {
                entity.ToTable("AssociateTimeRecurring", "Subjects");

                entity.HasIndex(e => e.AssociateTimeRecurringKey)
                    .HasName("IX_AssociateTimeRecurring_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.AssociateKey, e.TimeRecurringKey })
                    .HasName("IX_AssociateTimeRecurring_All")
                    .IsUnique();

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(50);


                entity.Property(e => e.TimeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ResourceTimeRecurring>(entity =>
            {
                entity.ToTable("ResourceTimeRecurring", "Subjects");

                entity.HasIndex(e => e.ResourceTimeRecurringKey)
                    .HasName("IX_ResourceTimeRecurring_Resource")
                    .IsUnique();

                entity.HasIndex(e => new { e.ResourceKey, e.TimeRecurringKey })
                    .HasName("IX_ResourceTimeRecurring_All")
                    .IsUnique();

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VentureTimeRecurring>(entity =>
            {
                entity.ToTable("VentureTimeRecurring", "Subjects");

                entity.HasIndex(e => e.VentureTimeRecurringKey)
                    .HasName("IX_VentureTimeRecurring_Venture")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.TimeRecurringKey })
                    .HasName("IX_VentureTimeRecurring_All")
                    .IsUnique();

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AssociateSchedule>(entity =>
            {
                entity.ToTable("AssociateSchedule", "Subjects");

                entity.HasIndex(e => e.AssociateScheduleKey)
                    .HasName("IX_AssociateSchedule_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.AssociateKey, e.ScheduleKey })
                    .HasName("IX_AssociateSchedule_All")
                    .IsUnique();
            });


            modelBuilder.Entity<ResourceSchedule>(entity =>
            {
                entity.ToTable("ResourceSchedule", "Subjects");

                entity.HasIndex(e => e.ResourceScheduleKey)
                    .HasName("IX_ResourceSchedule_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.ResourceKey, e.ScheduleKey })
                    .HasName("IX_ResourceSchedule_All")
                    .IsUnique();
            });

            modelBuilder.Entity<VentureSchedule>(entity =>
            {
                entity.ToTable("VentureSchedule", "Subjects");

                entity.HasIndex(e => e.VentureScheduleKey)
                    .HasName("IX_VentureSchedule_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.ScheduleKey })
                    .HasName("IX_VentureSchedule_All")
                    .IsUnique();
            });

            modelBuilder.Entity<TimeCycle>(entity =>
            {
                entity.ToTable("TimeCycle", "Entity");

                entity.HasIndex(e => e.TimeCycleKey)
                    .HasName("IX_TimeCycle_Key")
                    .IsUnique();

                entity.Property(e => e.TimeCycleDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.TimeCycleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TimeRange>(entity =>
            {
                entity.ToTable("TimeRange", "Entity");

                entity.HasIndex(e => e.TimeRangeKey)
                    .IsUnique();

                entity.HasIndex(e => new { e.BeginDate, e.EndDate })
                    .HasName("IX_TimeRange_All")
                    .IsUnique();

                entity.Property(e => e.BeginDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TimeRecurring>(entity =>
            {
                entity.ToTable("TimeRecurring", "Entity");

                entity.HasIndex(e => e.TimeRecurringKey)
                    .IsUnique();

                entity.HasIndex(e => new { e.BeginDay, e.EndDay, e.BeginTime, e.EndTime, e.Interval, e.TimeCycleKey })
                    .HasName("IX_TimeRecurring_All")
                    .IsUnique();

                entity.Property(e => e.BeginTime).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TimeType>(entity =>
            {
                entity.ToTable("TimeType", "Entity");

                entity.HasIndex(e => e.TimeTypeKey)
                    .HasName("IX_TimeType_Key")
                    .IsUnique();

                entity.Property(e => e.TimeTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.TimeTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
