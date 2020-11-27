using GoodToCode.Occurrences.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace GoodToCode.Occurrences.Infrastructure
{
    public partial class OccurrencesDbContext : DbContext, IOccurrencesDbContext
    {
        public OccurrencesDbContext(DbContextOptions<OccurrencesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<AssociateAppointment> AssociateAppointment { get; set; }
        public virtual DbSet<VentureAppointment> VentureAppointment { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventAppointment> AppointmentEvent { get; set; }
        public virtual DbSet<EventDetail> EventDetail { get; set; }
        public virtual DbSet<EventAssociateOption> EventAssociateOption { get; set; }
        public virtual DbSet<EventGroup> EventGroup { get; set; }
        public virtual DbSet<EventLocation> EventLocation { get; set; }
        public virtual DbSet<EventOption> EventOption { get; set; }
        public virtual DbSet<EventResource> EventResource { get; set; }
        public virtual DbSet<EventSchedule> EventSchedule { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment", "Occurrences");

                entity.HasIndex(e => e.AppointmentKey)
                    .HasName("IX_Appointment_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.SlotLocationKey, e.SlotResourceKey, e.TimeRangeKey })
                    .HasName("IX_LocationTime_All")
                    .IsUnique();

                entity.Property(e => e.AppointmentDescription)
                    .HasMaxLength(2000);

                entity.Property(e => e.AppointmentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AssociateAppointment>(entity =>
            {
                entity.ToTable("AssociateAppointment", "Occurrences");

                entity.HasIndex(e => e.AssociateAppointmentKey)
                    .HasName("IX_AssociateAppointment_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.AssociateKey, e.AppointmentKey })
                    .HasName("IX_AssociateAppointment_All")
                    .IsUnique();
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event", "Occurrences");

                entity.HasIndex(e => e.EventKey)
                    .IsUnique();

                entity.HasIndex(e => new { e.EventGroupKey, e.EventCreatorKey, e.EventName })
                    .HasName("IX_Event_All");

                entity.Property(e => e.EventDescription)
                    .HasMaxLength(250);

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EventSlogan)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EventAppointment>(entity =>
            {
                entity.ToTable("AppointmentEvent", "Occurrences");

                entity.HasIndex(e => e.AppointmentEventKey)
                    .HasName("IX_AppointmentEvent_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EventKey, e.AppointmentKey })
                    .HasName("IX_AppointmentEvent_All")
                    .IsUnique();
            });

            modelBuilder.Entity<EventDetail>(entity =>
            {
                entity.ToTable("EventDetail", "Occurrences");

                entity.HasIndex(e => e.EventDetailKey)
                    .HasName("IX_EventDetail_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EventKey, e.EventDetailKey })
                    .HasName("IX_EventDetail_All")
                    .IsUnique();
            });

            modelBuilder.Entity<EventAssociateOption>(entity =>
            {
                entity.ToTable("EventAssociateOption", "Occurrences");

                entity.HasIndex(e => e.EventAssociateOptionKey)
                    .HasName("IX_EventAssociateOption_Key")
                    .IsUnique();
            });

            modelBuilder.Entity<EventGroup>(entity =>
            {
                entity.ToTable("EventGroup", "Occurrences");

                entity.HasIndex(e => e.EventGroupKey)
                    .HasName("IX_EventGroup_Key")
                    .IsUnique();

                entity.Property(e => e.EventGroupDescription)
                    .HasMaxLength(250);

                entity.Property(e => e.EventGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EventLocation>(entity =>
            {
                entity.ToTable("EventLocation", "Occurrences");

                entity.HasIndex(e => e.EventLocationKey)
                    .HasName("IX_EventLocation_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EventKey, e.LocationKey })
                    .HasName("IX_EventLocation_All")
                    .IsUnique();
            });

            modelBuilder.Entity<EventOption>(entity =>
            {
                entity.ToTable("EventOption", "Occurrences");

                entity.HasIndex(e => new { e.EventKey, e.OptionKey })
                    .HasName("IX_EventOption_All")
                    .IsUnique();
            });

            modelBuilder.Entity<EventResource>(entity =>
            {
                entity.ToTable("EventResource", "Occurrences");

                entity.HasIndex(e => e.EventResourceKey)
                    .HasName("IX_EventResource_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EventKey, e.ResourceKey })
                    .HasName("IX_EventResource_All")
                    .IsUnique();

            });

            modelBuilder.Entity<EventSchedule>(entity =>
            {
                entity.ToTable("EventSchedule", "Occurrences");

                entity.HasIndex(e => e.EventScheduleKey)
                    .HasName("IX_EventSchedule_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EventKey, e.ScheduleKey })
                    .HasName("IX_EventSchedule_All")
                    .IsUnique();
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("EventType", "Occurrences");

                entity.HasIndex(e => e.EventTypeKey)
                    .HasName("IX_EventType_Key")
                    .IsUnique();

                entity.Property(e => e.EventTypeDescription)
                    .HasMaxLength(250);

                entity.Property(e => e.EventTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VentureAppointment>(entity =>
            {
                entity.ToTable("VentureAppointment", "Occurrences");

                entity.HasIndex(e => e.VentureAppointmentKey)
                    .HasName("IX_VentureAppointment_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.AppointmentKey })
                    .HasName("IX_VentureAppointment_All")
                    .IsUnique();
            });

            modelBuilder.Entity<AssociateAppointment>(entity =>
            {
                entity.ToTable("AssociateAppointment", "Subjects");

                entity.HasIndex(e => e.AssociateAppointmentKey)
                    .HasName("IX_AssociateAppointment_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.AssociateKey, e.AppointmentKey })
                    .HasName("IX_AssociateAppointment_All")
                    .IsUnique();
            });

            modelBuilder.Entity<VentureAppointment>(entity =>
            {
                entity.ToTable("VentureAppointment", "Subjects");

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
