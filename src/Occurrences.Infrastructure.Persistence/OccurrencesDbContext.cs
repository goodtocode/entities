﻿using GoodToCode.Occurrences.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Occurrences.Infrastructure
{
    public partial class OccurrencesDbContext : DbContext, IOccurrencesDbContext
    {
        public OccurrencesDbContext(DbContextOptions<OccurrencesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<EntityAppointment> EntityAppointment { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventAppointment> EventAppointment { get; set; }
        public virtual DbSet<EventDetail> EventDetail { get; set; }
        public virtual DbSet<EventEntityOption> EventEntityOption { get; set; }
        public virtual DbSet<EventGroup> EventGroup { get; set; }
        public virtual DbSet<EventLocation> EventLocation { get; set; }
        public virtual DbSet<EventOption> EventOption { get; set; }
        public virtual DbSet<EventResource> EventResource { get; set; }
        public virtual DbSet<EventSchedule> EventSchedule { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<VentureAppointment> VentureAppointment { get; set; }

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
            
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment", "Entity");

                entity.HasIndex(e => e.AppointmentKey)
                    .HasName("IX_Appointment_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.SlotLocationKey, e.SlotResourceKey, e.TimeRangeKey })
                    .HasName("IX_LocationTime_All")
                    .IsUnique();

                entity.Property(e => e.AppointmentDescription)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.AppointmentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EntityAppointment>(entity =>
            {
                entity.ToTable("EntityAppointment", "Entity");

                entity.HasIndex(e => e.EntityAppointmentKey)
                    .HasName("IX_EntityAppointment_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntityKey, e.AppointmentKey })
                    .HasName("IX_EntityAppointment_All")
                    .IsUnique();
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event", "Entity");

                entity.HasIndex(e => e.EventKey)
                    .IsUnique();

                entity.HasIndex(e => new { e.EventGroupKey, e.EventCreatorKey, e.EventName })
                    .HasName("IX_Event_All");

                entity.Property(e => e.EventDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EventSlogan)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EventAppointment>(entity =>
            {
                entity.ToTable("EventAppointment", "Entity");

                entity.HasIndex(e => e.EventAppointmentKey)
                    .HasName("IX_EventAppointment_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EventKey, e.AppointmentKey })
                    .HasName("IX_EventAppointment_All")
                    .IsUnique();
            });

            modelBuilder.Entity<EventDetail>(entity =>
            {
                entity.ToTable("EventDetail", "Entity");

                entity.HasIndex(e => e.EventDetailKey)
                    .HasName("IX_EventDetail_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EventKey, e.EventDetailKey })
                    .HasName("IX_EventDetail_All")
                    .IsUnique();
            });

            modelBuilder.Entity<EventEntityOption>(entity =>
            {
                entity.ToTable("EventEntityOption", "Entity");

                entity.HasIndex(e => e.EventEntityOptionKey)
                    .HasName("IX_EventEntityOption_Key")
                    .IsUnique();
            });

            modelBuilder.Entity<EventGroup>(entity =>
            {
                entity.ToTable("EventGroup", "Entity");

                entity.HasIndex(e => e.EventGroupKey)
                    .HasName("IX_EventGroup_Key")
                    .IsUnique();

                entity.Property(e => e.EventGroupDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EventGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EventLocation>(entity =>
            {
                entity.ToTable("EventLocation", "Entity");

                entity.HasIndex(e => e.EventLocationKey)
                    .HasName("IX_EventLocation_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EventKey, e.LocationKey })
                    .HasName("IX_EventLocation_All")
                    .IsUnique();
            });

            modelBuilder.Entity<EventOption>(entity =>
            {
                entity.ToTable("EventOption", "Entity");

                entity.HasIndex(e => new { e.EventKey, e.OptionKey })
                    .HasName("IX_EventOption_All")
                    .IsUnique();
            });

            modelBuilder.Entity<EventResource>(entity =>
            {
                entity.ToTable("EventResource", "Entity");

                entity.HasIndex(e => e.EventResourceKey)
                    .HasName("IX_EventResource_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EventKey, e.ResourceKey })
                    .HasName("IX_EventResource_All")
                    .IsUnique();

            });

            modelBuilder.Entity<EventSchedule>(entity =>
            {
                entity.ToTable("EventSchedule", "Entity");

                entity.HasIndex(e => e.EventScheduleKey)
                    .HasName("IX_EventSchedule_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EventKey, e.ScheduleKey })
                    .HasName("IX_EventSchedule_All")
                    .IsUnique();
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("EventType", "Entity");

                entity.HasIndex(e => e.EventTypeKey)
                    .HasName("IX_EventType_Key")
                    .IsUnique();

                entity.Property(e => e.EventTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EventTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VentureAppointment>(entity =>
            {
                entity.ToTable("VentureAppointment", "Entity");

                entity.HasIndex(e => e.VentureAppointmentKey)
                    .HasName("IX_VentureAppointment_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.AppointmentKey })
                    .HasName("IX_VentureAppointment_All")
                    .IsUnique();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
