using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

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
        public virtual DbSet<LocationTimeRecurring> LocationTimeRecurring { get; set; }
        public virtual DbSet<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        public virtual DbSet<VentureTimeRecurring> VentureTimeRecurring { get; set; }
        public virtual DbSet<AssociateSchedule> AssociateSchedule { get; set; }
        public virtual DbSet<ResourceSchedule> ResourceSchedule { get; set; }
        public virtual DbSet<VentureSchedule> VentureSchedule { get; set; }
        public virtual DbSet<TimeCycle> TimeCycle { get; set; }
        public virtual DbSet<TimeRange> TimeRange { get; set; }
        public virtual DbSet<TimeRecurring> TimeRecurring { get; set; }
        public virtual DbSet<TimeType> TimeType { get; set; }

        public string GetConnectionFromAzureSettings(string configKey)
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfigurationWithSentinel(Environment.GetEnvironmentVariable("AppSettingsConnection"), "Stack:Shared:Sentinel");
            builder.AddAzureAppConfigurationWithSentinel(Environment.GetEnvironmentVariable("AppSettingsConnection"), "Stack:Shared:Sentinel");
            var config = builder.Build();

            return config[configKey];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionFromAzureSettings("Stack:Shared:SqlConnection"));
                //optionsBuilder.UseCosmos(GetConnectionFromAzureSettings("Stack:Shared:CosmosConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule", "Chronology");

                entity.HasIndex(e => e.ScheduleKey)
                    .IsUnique();

                entity.Property(e => e.ScheduleDescription)
                    .HasMaxLength(2000);

                entity.Property(e => e.ScheduleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ScheduleSlot>(entity =>
            {
                entity.ToTable("ScheduleSlot", "Chronology");

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
                entity.ToTable("ScheduleType", "Chronology");

                entity.HasIndex(e => e.ScheduleTypeKey)
                    .HasName("IX_ScheduleType_Key")
                    .IsUnique();

                entity.Property(e => e.ScheduleTypeDescription)
                    .HasMaxLength(250);

                entity.Property(e => e.ScheduleTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot", "Chronology");

                entity.HasIndex(e => e.SlotKey)
                    .IsUnique();

                entity.Property(e => e.SlotDescription)
                    .HasMaxLength(2000);

                entity.Property(e => e.SlotName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SlotLocation>(entity =>
            {
                entity.ToTable("SlotLocation", "Chronology");

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
                entity.ToTable("SlotResource", "Chronology");

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
                entity.ToTable("SlotTimeRange", "Chronology");

                entity.HasIndex(e => e.SlotKey)
                    .HasName("IX_SlotTimeRange_Slot");

                entity.HasIndex(e => new { e.SlotKey, e.TimeRangeKey })
                    .HasName("IX_SlotTime_All")
                    .IsUnique();
            });

            modelBuilder.Entity<SlotTimeRecurring>(entity =>
            {
                entity.ToTable("SlotTimeRecurring", "Chronology");

                entity.HasIndex(e => e.SlotKey)
                    .HasName("IX_SlotTimeRecurring_Slot");

                entity.HasIndex(e => new { e.SlotKey, e.TimeRecurringKey })
                    .HasName("IX_SlotTime_All")
                    .IsUnique();
            });

            modelBuilder.Entity<AssociateTimeRecurring>(entity =>
            {
                entity.ToTable("AssociateTimeRecurring", "Chronology");

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

            modelBuilder.Entity<LocationTimeRecurring>(entity =>
            {
                entity.ToTable("LocationTimeRecurring", "Chronology");

                entity.HasIndex(e => e.LocationTimeRecurringKey)
                    .HasName("IX_LocationTimeRecurring_Location")
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

            modelBuilder.Entity<ResourceTimeRecurring>(entity =>
            {
                entity.ToTable("ResourceTimeRecurring", "Chronology");

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
                entity.ToTable("VentureTimeRecurring", "Chronology");

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
                entity.ToTable("AssociateSchedule", "Chronology");

                entity.HasIndex(e => e.AssociateScheduleKey)
                    .HasName("IX_AssociateSchedule_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.AssociateKey, e.ScheduleKey })
                    .HasName("IX_AssociateSchedule_All")
                    .IsUnique();
            });


            modelBuilder.Entity<ResourceSchedule>(entity =>
            {
                entity.ToTable("ResourceSchedule", "Chronology");

                entity.HasIndex(e => e.ResourceScheduleKey)
                    .HasName("IX_ResourceSchedule_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.ResourceKey, e.ScheduleKey })
                    .HasName("IX_ResourceSchedule_All")
                    .IsUnique();
            });

            modelBuilder.Entity<VentureSchedule>(entity =>
            {
                entity.ToTable("VentureSchedule", "Chronology");

                entity.HasIndex(e => e.VentureScheduleKey)
                    .HasName("IX_VentureSchedule_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.ScheduleKey })
                    .HasName("IX_VentureSchedule_All")
                    .IsUnique();
            });

            modelBuilder.Entity<TimeCycle>(entity =>
            {
                entity.ToTable("TimeCycle", "Chronology");

                entity.HasIndex(e => e.TimeCycleKey)
                    .HasName("IX_TimeCycle_Key")
                    .IsUnique();

                entity.Property(e => e.TimeCycleDescription)
                    .HasMaxLength(250);

                entity.Property(e => e.TimeCycleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TimeRange>(entity =>
            {
                entity.ToTable("TimeRange", "Chronology");

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
                entity.ToTable("TimeRecurring", "Chronology");

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
                entity.ToTable("TimeType", "Chronology");

                entity.HasIndex(e => e.TimeTypeKey)
                    .HasName("IX_TimeType_Key")
                    .IsUnique();

                entity.Property(e => e.TimeTypeDescription)
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
