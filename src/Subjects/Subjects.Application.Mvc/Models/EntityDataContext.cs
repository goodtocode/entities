
//https://www.syncfusion.com/blogs/post/build-crud-application-with-asp-net-core-entity-framework-visual-studio-2019.aspx
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace GoodToCode.Subjects.Models
{
    public partial class EntityDataContext : DbContext
    {
        public EntityDataContext()
        {
        }

        public EntityDataContext(DbContextOptions<EntityDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<DetailType> DetailType { get; set; }
        public virtual DbSet<Entity> Entity { get; set; }
        public virtual DbSet<EntityAppointment> EntityAppointment { get; set; }
        public virtual DbSet<EntityDetail> EntityDetail { get; set; }
        public virtual DbSet<EntityLocation> EntityLocation { get; set; }
        public virtual DbSet<EntityOption> EntityOption { get; set; }
        public virtual DbSet<EntityTimeRecurring> EntityTimeRecurring { get; set; }
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
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Government> Government { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemGroup> ItemGroup { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationArea> LocationArea { get; set; }
        public virtual DbSet<LocationTimeRecurring> LocationTimeRecurring { get; set; }
        public virtual DbSet<LocationType> LocationType { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<OptionGroup> OptionGroup { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<RecordState> RecordState { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<ResourceItem> ResourceItem { get; set; }
        public virtual DbSet<ResourcePerson> ResourcePerson { get; set; }
        public virtual DbSet<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        public virtual DbSet<ResourceType> ResourceType { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<ScheduleSlot> ScheduleSlot { get; set; }
        public virtual DbSet<ScheduleType> ScheduleType { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<SettingType> SettingType { get; set; }
        public virtual DbSet<Slot> Slot { get; set; }
        public virtual DbSet<SlotLocation> SlotLocation { get; set; }
        public virtual DbSet<SlotResource> SlotResource { get; set; }
        public virtual DbSet<SlotTimeRange> SlotTimeRange { get; set; }
        public virtual DbSet<SlotTimeRecurring> SlotTimeRecurring { get; set; }
        public virtual DbSet<TimeCycle> TimeCycle { get; set; }
        public virtual DbSet<TimeRange> TimeRange { get; set; }
        public virtual DbSet<TimeRecurring> TimeRecurring { get; set; }
        public virtual DbSet<TimeType> TimeType { get; set; }
        public virtual DbSet<Venture> Venture { get; set; }
        public virtual DbSet<VentureAppointment> VentureAppointment { get; set; }
        public virtual DbSet<VentureDetail> VentureDetail { get; set; }


        public virtual DbSet<VentureEntityOption> VentureEntityOption { get; set; }
        public virtual DbSet<VentureLocation> VentureLocation { get; set; }
        public virtual DbSet<VentureOption> VentureOption { get; set; }
        public virtual DbSet<VentureResource> VentureResource { get; set; }
        public virtual DbSet<VentureSchedule> VentureSchedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
              .AddJsonFile($"appsettings.{(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development")}.json")
              .AddJsonFile("appsettings.json")
              .Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            connectionString = "Server=tcp:GoodToCode.database.windows.net,1433;Initial Catalog=EntityData;user id=TestUser; password=;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Application Name=GoodToCodeEntities;";
            if (!optionsBuilder.IsConfigured)
            {
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Appointment)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_RecordState");

                entity.HasOne(d => d.SlotLocationKeyNavigation)
                    .WithMany(p => p.Appointment)
                    .HasPrincipalKey(p => p.SlotLocationKey)
                    .HasForeignKey(d => d.SlotLocationKey)
                    .HasConstraintName("FK_Appointment_Location");

                entity.HasOne(d => d.SlotResourceKeyNavigation)
                    .WithMany(p => p.Appointment)
                    .HasPrincipalKey(p => p.SlotResourceKey)
                    .HasForeignKey(d => d.SlotResourceKey)
                    .HasConstraintName("FK_Appointment_Resource");

                entity.HasOne(d => d.TimeRangeKeyNavigation)
                    .WithMany(p => p.Appointment)
                    .HasPrincipalKey(p => p.TimeRangeKey)
                    .HasForeignKey(d => d.TimeRangeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_TimeRange");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area", "Entity");

                entity.HasIndex(e => e.AreaKey)
                    .HasName("IX_Area_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("Business", "Entity");

                entity.HasIndex(e => e.BusinessKey)
                    .HasName("IX_BusinessEntity_Entity")
                    .IsUnique();

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TaxNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.BusinessKeyNavigation)
                    .WithOne(p => p.Business)
                    .HasPrincipalKey<Entity>(p => p.EntityKey)
                    .HasForeignKey<Business>(d => d.BusinessKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Business_Entity");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Business)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Business_RecordState");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.ToTable("Detail", "Entity");

                entity.HasIndex(e => e.DetailKey)
                    .HasName("IX_Detail_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DetailData)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DetailTypeKeyNavigation)
                    .WithMany(p => p.Detail)
                    .HasPrincipalKey(p => p.DetailTypeKey)
                    .HasForeignKey(d => d.DetailTypeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detail_DetailType");
            });

            modelBuilder.Entity<DetailType>(entity =>
            {
                entity.ToTable("DetailType", "Entity");

                entity.HasIndex(e => e.DetailTypeKey)
                    .HasName("IX_DetailType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DetailTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.DetailTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.ToTable("Entity", "Entity");

                entity.HasIndex(e => e.EntityKey)
                    .HasName("IX_EntityLocation_Entity")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AppointmentKeyNavigation)
                    .WithMany(p => p.EntityAppointment)
                    .HasPrincipalKey(p => p.AppointmentKey)
                    .HasForeignKey(d => d.AppointmentKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityAppointment_Appointment");

                entity.HasOne(d => d.EntityKeyNavigation)
                    .WithMany(p => p.EntityAppointment)
                    .HasPrincipalKey(p => p.EntityKey)
                    .HasForeignKey(d => d.EntityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityAppointment_Entity");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.EntityAppointment)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityAppointment_RecordState");
            });

            modelBuilder.Entity<EntityDetail>(entity =>
            {
                entity.ToTable("EntityDetail", "Entity");

                entity.HasIndex(e => e.EntityDetailKey)
                    .HasName("IX_EntityDetail_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntityKey, e.EntityDetailKey })
                    .HasName("IX_EntityDetail_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DetailKeyNavigation)
                    .WithMany(p => p.EntityDetail)
                    .HasPrincipalKey(p => p.DetailKey)
                    .HasForeignKey(d => d.DetailKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityDetail_Detail");

                entity.HasOne(d => d.EntityKeyNavigation)
                    .WithMany(p => p.EntityDetail)
                    .HasPrincipalKey(p => p.EntityKey)
                    .HasForeignKey(d => d.EntityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityDetail_Entity");
            });

            modelBuilder.Entity<EntityLocation>(entity =>
            {
                entity.ToTable("EntityLocation", "Entity");

                entity.HasIndex(e => new { e.EntityKey, e.LocationKey })
                    .HasName("IX_EntityLocation_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntityKeyNavigation)
                    .WithMany(p => p.EntityLocation)
                    .HasPrincipalKey(p => p.EntityKey)
                    .HasForeignKey(d => d.EntityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityLocation_Entity");

                entity.HasOne(d => d.LocationKeyNavigation)
                    .WithMany(p => p.EntityLocation)
                    .HasPrincipalKey(p => p.LocationKey)
                    .HasForeignKey(d => d.LocationKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityLocation_Location");

                entity.HasOne(d => d.LocationTypeKeyNavigation)
                    .WithMany(p => p.EntityLocation)
                    .HasPrincipalKey(p => p.LocationTypeKey)
                    .HasForeignKey(d => d.LocationTypeKey)
                    .HasConstraintName("FK_EntityLocation_LocationType");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.EntityLocation)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityLocation_RecordState");
            });

            modelBuilder.Entity<EntityOption>(entity =>
            {
                entity.ToTable("EntityOption", "Entity");

                entity.HasIndex(e => new { e.EntityKey, e.OptionKey })
                    .HasName("IX_EntityOption_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.OptionKeyNavigation)
                    .WithMany(p => p.EntityOption)
                    .HasPrincipalKey(p => p.OptionKey)
                    .HasForeignKey(d => d.OptionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityOption_Option");
            });

            modelBuilder.Entity<EntityTimeRecurring>(entity =>
            {
                entity.ToTable("EntityTimeRecurring", "Entity");

                entity.HasIndex(e => e.EntityTimeRecurringKey)
                    .HasName("IX_EntityTimeRecurring_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntityKey, e.TimeRecurringKey })
                    .HasName("IX_EntityTimeRecurring_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TimeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.EntityKeyNavigation)
                    .WithMany(p => p.EntityTimeRecurring)
                    .HasPrincipalKey(p => p.EntityKey)
                    .HasForeignKey(d => d.EntityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityTimeRecurring_Entity");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.EntityTimeRecurring)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityTimeRecurring_RecordState");

                entity.HasOne(d => d.TimeRecurringKeyNavigation)
                    .WithMany(p => p.EntityTimeRecurring)
                    .HasPrincipalKey(p => p.TimeRecurringKey)
                    .HasForeignKey(d => d.TimeRecurringKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EntityTimeRecurring_TimeRecurring");

                entity.HasOne(d => d.TimeTypeKeyNavigation)
                    .WithMany(p => p.EntityTimeRecurring)
                    .HasPrincipalKey(p => p.TimeTypeKey)
                    .HasForeignKey(d => d.TimeTypeKey)
                    .HasConstraintName("FK_EntityAvailable_TimeType");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event", "Entity");

                entity.HasIndex(e => e.EventKey)
                    .IsUnique();

                entity.HasIndex(e => new { e.EventGroupKey, e.EventCreatorKey, e.EventName })
                    .HasName("IX_Event_All");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EventDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EventSlogan)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EventCreatorKeyNavigation)
                    .WithMany(p => p.Event)
                    .HasPrincipalKey(p => p.EntityKey)
                    .HasForeignKey(d => d.EventCreatorKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_Entity");

                entity.HasOne(d => d.EventGroupKeyNavigation)
                    .WithMany(p => p.Event)
                    .HasPrincipalKey(p => p.EventGroupKey)
                    .HasForeignKey(d => d.EventGroupKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_EventGroup");

                entity.HasOne(d => d.EventTypeKeyNavigation)
                    .WithMany(p => p.Event)
                    .HasPrincipalKey(p => p.EventTypeKey)
                    .HasForeignKey(d => d.EventTypeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_EventType");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Event)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_RecordState");
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AppointmentKeyNavigation)
                    .WithMany(p => p.EventAppointment)
                    .HasPrincipalKey(p => p.AppointmentKey)
                    .HasForeignKey(d => d.AppointmentKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventAppointment_Appointment");

                entity.HasOne(d => d.EventKeyNavigation)
                    .WithMany(p => p.EventAppointment)
                    .HasPrincipalKey(p => p.EventKey)
                    .HasForeignKey(d => d.EventKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventAppointment_Event");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.EventAppointment)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventAppointment_RecordState");
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DetailKeyNavigation)
                    .WithMany(p => p.EventDetail)
                    .HasPrincipalKey(p => p.DetailKey)
                    .HasForeignKey(d => d.DetailKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventDetail_Detail");

                entity.HasOne(d => d.EventKeyNavigation)
                    .WithMany(p => p.EventDetail)
                    .HasPrincipalKey(p => p.EventKey)
                    .HasForeignKey(d => d.EventKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventDetail_Event");
            });

            modelBuilder.Entity<EventEntityOption>(entity =>
            {
                entity.ToTable("EventEntityOption", "Entity");

                entity.HasIndex(e => e.EventEntityOptionKey)
                    .HasName("IX_EventEntityOption_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntityKeyNavigation)
                    .WithMany(p => p.EventEntityOption)
                    .HasPrincipalKey(p => p.EntityKey)
                    .HasForeignKey(d => d.EntityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventEntityOption_Entity");

                entity.HasOne(d => d.EventKeyNavigation)
                    .WithMany(p => p.EventEntityOption)
                    .HasPrincipalKey(p => p.EventKey)
                    .HasForeignKey(d => d.EventKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventEntityOption_Event");

                entity.HasOne(d => d.OptionKeyNavigation)
                    .WithMany(p => p.EventEntityOption)
                    .HasPrincipalKey(p => p.OptionKey)
                    .HasForeignKey(d => d.OptionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventEntityOption_Option");
            });

            modelBuilder.Entity<EventGroup>(entity =>
            {
                entity.ToTable("EventGroup", "Entity");

                entity.HasIndex(e => e.EventGroupKey)
                    .HasName("IX_EventGroup_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EventGroupDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EventGroupName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EventKeyNavigation)
                    .WithMany(p => p.EventLocation)
                    .HasPrincipalKey(p => p.EventKey)
                    .HasForeignKey(d => d.EventKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventLocation_Event");

                entity.HasOne(d => d.LocationKeyNavigation)
                    .WithMany(p => p.EventLocation)
                    .HasPrincipalKey(p => p.LocationKey)
                    .HasForeignKey(d => d.LocationKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventLocation_Location");

                entity.HasOne(d => d.LocationTypeKeyNavigation)
                    .WithMany(p => p.EventLocation)
                    .HasPrincipalKey(p => p.LocationTypeKey)
                    .HasForeignKey(d => d.LocationTypeKey)
                    .HasConstraintName("FK_EventLocation_LocationType");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.EventLocation)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventLocation_RecordState");
            });

            modelBuilder.Entity<EventOption>(entity =>
            {
                entity.ToTable("EventOption", "Entity");

                entity.HasIndex(e => new { e.EventKey, e.OptionKey })
                    .HasName("IX_EventOption_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EventKeyNavigation)
                    .WithMany(p => p.EventOption)
                    .HasPrincipalKey(p => p.EventKey)
                    .HasForeignKey(d => d.EventKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventOption_Event");

                entity.HasOne(d => d.OptionKeyNavigation)
                    .WithMany(p => p.EventOption)
                    .HasPrincipalKey(p => p.OptionKey)
                    .HasForeignKey(d => d.OptionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventOption_Option");
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EventKeyNavigation)
                    .WithMany(p => p.EventResource)
                    .HasPrincipalKey(p => p.EventKey)
                    .HasForeignKey(d => d.EventKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventResource_Event");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.EventResource)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventResource_RecordState");

                entity.HasOne(d => d.ResourceKeyNavigation)
                    .WithMany(p => p.EventResource)
                    .HasPrincipalKey(p => p.ResourceKey)
                    .HasForeignKey(d => d.ResourceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventResource_Resource");

                entity.HasOne(d => d.ResourceTypeKeyNavigation)
                    .WithMany(p => p.EventResource)
                    .HasPrincipalKey(p => p.ResourceTypeKey)
                    .HasForeignKey(d => d.ResourceTypeKey)
                    .HasConstraintName("FK_EventResource_ResourceType");
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EventKeyNavigation)
                    .WithMany(p => p.EventSchedule)
                    .HasPrincipalKey(p => p.EventKey)
                    .HasForeignKey(d => d.EventKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventSchedule_Event");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.EventSchedule)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventSchedule_RecordState");

                entity.HasOne(d => d.ScheduleKeyNavigation)
                    .WithMany(p => p.EventSchedule)
                    .HasPrincipalKey(p => p.ScheduleKey)
                    .HasForeignKey(d => d.ScheduleKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventSchedule_Schedule");

                entity.HasOne(d => d.ScheduleTypeKeyNavigation)
                    .WithMany(p => p.EventSchedule)
                    .HasPrincipalKey(p => p.ScheduleTypeKey)
                    .HasForeignKey(d => d.ScheduleTypeKey)
                    .HasConstraintName("FK_EventSchedule_ScheduleType");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("EventType", "Entity");

                entity.HasIndex(e => e.EventTypeKey)
                    .HasName("IX_EventType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EventTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EventTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EventGroupKeyNavigation)
                    .WithMany(p => p.EventType)
                    .HasPrincipalKey(p => p.EventGroupKey)
                    .HasForeignKey(d => d.EventGroupKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventType_EventGroup");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender", "Entity");

                entity.HasIndex(e => e.GenderCode)
                    .HasName("IX_Gender_Code")
                    .IsUnique();

                entity.HasIndex(e => e.GenderKey)
                    .HasName("IX_Gender_Key")
                    .IsUnique();

                entity.Property(e => e.GenderId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GenderCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Government>(entity =>
            {
                entity.ToTable("Government", "Entity");

                entity.HasIndex(e => e.GovernmentKey)
                    .HasName("IX_Government_Entity")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.GovernmentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.GovernmentKeyNavigation)
                    .WithOne(p => p.Government)
                    .HasPrincipalKey<Entity>(p => p.EntityKey)
                    .HasForeignKey<Government>(d => d.GovernmentKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Government_Entity");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Government)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Government_RecordState");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item", "Entity");

                entity.HasIndex(e => e.ItemKey)
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Item)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_RecordState");
            });

            modelBuilder.Entity<ItemGroup>(entity =>
            {
                entity.ToTable("ItemGroup", "Entity");

                entity.HasIndex(e => e.ItemGroupKey)
                    .HasName("IX_ItemGroup_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemGroupDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ItemGroupName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("ItemType", "Entity");

                entity.HasIndex(e => e.ItemTypeKey)
                    .HasName("IX_ItemType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ItemTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ItemGroupKeyNavigation)
                    .WithMany(p => p.ItemType)
                    .HasPrincipalKey(p => p.ItemGroupKey)
                    .HasForeignKey(d => d.ItemGroupKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemType_ItemGroup");
            });

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

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_MigrationHistory");

                entity.ToTable("__MigrationHistory", "Identity");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("Option", "Entity");

                entity.HasIndex(e => e.OptionKey)
                    .IsUnique();

                entity.HasIndex(e => new { e.OptionGroupKey, e.OptionCode })
                    .HasName("IX_Option_OptionCode")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OptionCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.OptionDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.OptionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.OptionGroupKeyNavigation)
                    .WithMany(p => p.Option)
                    .HasPrincipalKey(p => p.OptionGroupKey)
                    .HasForeignKey(d => d.OptionGroupKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Option_OptionGroup");
            });

            modelBuilder.Entity<OptionGroup>(entity =>
            {
                entity.ToTable("OptionGroup", "Entity");

                entity.HasIndex(e => e.OptionGroupCode)
                    .HasName("IX_Option_OptionGroupCode")
                    .IsUnique();

                entity.HasIndex(e => e.OptionGroupKey)
                    .HasName("IX_Option_OptionGroupKey")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OptionGroupCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.OptionGroupDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.OptionGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "Entity");

                entity.HasIndex(e => e.PersonKey)
                    .HasName("IX_Person_Entity")
                    .IsUnique();

                entity.HasIndex(e => new { e.FirstName, e.MiddleName, e.LastName, e.BirthDate })
                    .HasName("IX_Person_All");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Gender");

                entity.HasOne(d => d.PersonKeyNavigation)
                    .WithOne(p => p.Person)
                    .HasPrincipalKey<Entity>(p => p.EntityKey)
                    .HasForeignKey<Person>(d => d.PersonKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Entity");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Person)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_RecordState");
            });

            modelBuilder.Entity<RecordState>(entity =>
            {
                entity.ToTable("RecordState", "Entity");

                entity.HasIndex(e => e.RecordStateKey)
                    .HasName("IX_RecordState_Key")
                    .IsUnique();

                entity.Property(e => e.RecordStateId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RecordStateName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.ToTable("Resource", "Entity");

                entity.HasIndex(e => e.ResourceKey)
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ResourceDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ResourceName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Resource)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resource_RecordState");
            });

            modelBuilder.Entity<ResourceItem>(entity =>
            {
                entity.ToTable("ResourceItem", "Entity");

                entity.HasIndex(e => e.ItemKey)
                    .HasName("IX_ResourceItem_Item");

                entity.HasIndex(e => e.ResourceItemKey)
                    .HasName("IX_ResourceItem_Key")
                    .IsUnique();

                entity.HasIndex(e => e.ResourceKey)
                    .HasName("IX_ResourceItem_Resource");

                entity.HasIndex(e => new { e.ResourceKey, e.ItemKey })
                    .HasName("IX_ResourceItem_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ItemKeyNavigation)
                    .WithMany(p => p.ResourceItem)
                    .HasPrincipalKey(p => p.ItemKey)
                    .HasForeignKey(d => d.ItemKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceItem_Item");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.ResourceItem)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceItem_RecordState");

                entity.HasOne(d => d.ResourceKeyNavigation)
                    .WithMany(p => p.ResourceItem)
                    .HasPrincipalKey(p => p.ResourceKey)
                    .HasForeignKey(d => d.ResourceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceItem_Resource");
            });

            modelBuilder.Entity<ResourcePerson>(entity =>
            {
                entity.ToTable("ResourcePerson", "Entity");

                entity.HasIndex(e => e.PersonKey)
                    .HasName("IX_ResourcePerson_Person");

                entity.HasIndex(e => e.ResourceKey)
                    .HasName("IX_ResourcePerson_Resource");

                entity.HasIndex(e => e.ResourcePersonKey)
                    .HasName("IX_ResourcePerson_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.ResourceKey, e.PersonKey })
                    .HasName("IX_ResourcePerson_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.PersonKeyNavigation)
                    .WithMany(p => p.ResourcePerson)
                    .HasPrincipalKey(p => p.PersonKey)
                    .HasForeignKey(d => d.PersonKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourcePerson_Person");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.ResourcePerson)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourcePerson_RecordState");

                entity.HasOne(d => d.ResourceKeyNavigation)
                    .WithMany(p => p.ResourcePerson)
                    .HasPrincipalKey(p => p.ResourceKey)
                    .HasForeignKey(d => d.ResourceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceResource_Resource");
            });

            modelBuilder.Entity<ResourceTimeRecurring>(entity =>
            {
                entity.ToTable("ResourceTimeRecurring", "Entity");

                entity.HasIndex(e => e.ResourceTimeRecurringKey)
                    .HasName("IX_ResourceTimeRecurring_Resource")
                    .IsUnique();

                entity.HasIndex(e => new { e.ResourceKey, e.TimeRecurringKey })
                    .HasName("IX_ResourceTimeRecurring_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TimeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.ResourceTimeRecurring)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceTimeRecurring_RecordState");

                entity.HasOne(d => d.ResourceKeyNavigation)
                    .WithMany(p => p.ResourceTimeRecurring)
                    .HasPrincipalKey(p => p.ResourceKey)
                    .HasForeignKey(d => d.ResourceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceTimeRecurring_Resource");

                entity.HasOne(d => d.TimeRecurringKeyNavigation)
                    .WithMany(p => p.ResourceTimeRecurring)
                    .HasPrincipalKey(p => p.TimeRecurringKey)
                    .HasForeignKey(d => d.TimeRecurringKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceTimeRecurring_TimeRecurring");

                entity.HasOne(d => d.TimeTypeKeyNavigation)
                    .WithMany(p => p.ResourceTimeRecurring)
                    .HasPrincipalKey(p => p.TimeTypeKey)
                    .HasForeignKey(d => d.TimeTypeKey)
                    .HasConstraintName("FK_ResourceTimeRecurring_TimeType");
            });

            modelBuilder.Entity<ResourceType>(entity =>
            {
                entity.ToTable("ResourceType", "Entity");

                entity.HasIndex(e => e.ResourceTypeKey)
                    .HasName("IX_ResourceType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ResourceTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ResourceTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule", "Entity");

                entity.HasIndex(e => e.ScheduleKey)
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ScheduleDescription)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ScheduleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Schedule)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_RecordState");
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ScheduleKeyNavigation)
                    .WithMany(p => p.ScheduleSlot)
                    .HasPrincipalKey(p => p.ScheduleKey)
                    .HasForeignKey(d => d.ScheduleKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleSlot_Schedule");

                entity.HasOne(d => d.SlotKeyNavigation)
                    .WithMany(p => p.ScheduleSlot)
                    .HasPrincipalKey(p => p.SlotKey)
                    .HasForeignKey(d => d.SlotKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleSlot_Slot");
            });

            modelBuilder.Entity<ScheduleType>(entity =>
            {
                entity.ToTable("ScheduleType", "Entity");

                entity.HasIndex(e => e.ScheduleTypeKey)
                    .HasName("IX_ScheduleType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ScheduleTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ScheduleTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("Setting", "Setting");

                entity.HasIndex(e => e.SettingKey)
                    .HasName("IX_Setting_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SettingName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SettingValue)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<SettingType>(entity =>
            {
                entity.ToTable("SettingType", "Setting");

                entity.HasIndex(e => e.SettingTypeKey)
                    .HasName("IX_SettingType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SettingTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot", "Entity");

                entity.HasIndex(e => e.SlotKey)
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SlotDescription)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.SlotName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Slot)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Slot_RecordState");
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.LocationKeyNavigation)
                    .WithMany(p => p.SlotLocation)
                    .HasPrincipalKey(p => p.LocationKey)
                    .HasForeignKey(d => d.LocationKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotLocation_Location");

                entity.HasOne(d => d.LocationTypeKeyNavigation)
                    .WithMany(p => p.SlotLocation)
                    .HasPrincipalKey(p => p.LocationTypeKey)
                    .HasForeignKey(d => d.LocationTypeKey)
                    .HasConstraintName("FK_SlotLocation_LocationType");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.SlotLocation)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotLocation_RecordState");

                entity.HasOne(d => d.SlotKeyNavigation)
                    .WithMany(p => p.SlotLocation)
                    .HasPrincipalKey(p => p.SlotKey)
                    .HasForeignKey(d => d.SlotKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotLocation_Slot");
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.SlotResource)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotResource_RecordState");

                entity.HasOne(d => d.ResourceKeyNavigation)
                    .WithMany(p => p.SlotResource)
                    .HasPrincipalKey(p => p.ResourceKey)
                    .HasForeignKey(d => d.ResourceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotResource_Resource");

                entity.HasOne(d => d.ResourceTypeKeyNavigation)
                    .WithMany(p => p.SlotResource)
                    .HasPrincipalKey(p => p.ResourceTypeKey)
                    .HasForeignKey(d => d.ResourceTypeKey)
                    .HasConstraintName("FK_SlotResource_ResourceType");

                entity.HasOne(d => d.SlotKeyNavigation)
                    .WithMany(p => p.SlotResource)
                    .HasPrincipalKey(p => p.SlotKey)
                    .HasForeignKey(d => d.SlotKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotResource_Slot");
            });

            modelBuilder.Entity<SlotTimeRange>(entity =>
            {
                entity.ToTable("SlotTimeRange", "Entity");

                entity.HasIndex(e => e.SlotKey)
                    .HasName("IX_SlotTimeRange_Slot");

                entity.HasIndex(e => new { e.SlotKey, e.TimeRangeKey })
                    .HasName("IX_SlotTime_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.SlotTimeRange)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotTimeRange_RecordState");

                entity.HasOne(d => d.SlotKeyNavigation)
                    .WithMany(p => p.SlotTimeRange)
                    .HasPrincipalKey(p => p.SlotKey)
                    .HasForeignKey(d => d.SlotKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotTimeRange_Slot");

                entity.HasOne(d => d.TimeRangeKeyNavigation)
                    .WithMany(p => p.SlotTimeRange)
                    .HasPrincipalKey(p => p.TimeRangeKey)
                    .HasForeignKey(d => d.TimeRangeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotTimeRange_TimeRange");

                entity.HasOne(d => d.TimeTypeKeyNavigation)
                    .WithMany(p => p.SlotTimeRange)
                    .HasPrincipalKey(p => p.TimeTypeKey)
                    .HasForeignKey(d => d.TimeTypeKey)
                    .HasConstraintName("FK_SlotTimeRange_TimeType");
            });

            modelBuilder.Entity<SlotTimeRecurring>(entity =>
            {
                entity.ToTable("SlotTimeRecurring", "Entity");

                entity.HasIndex(e => e.SlotKey)
                    .HasName("IX_SlotTimeRecurring_Slot");

                entity.HasIndex(e => new { e.SlotKey, e.TimeRecurringKey })
                    .HasName("IX_SlotTime_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.SlotTimeRecurring)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotTimeRecurring_RecordState");

                entity.HasOne(d => d.SlotKeyNavigation)
                    .WithMany(p => p.SlotTimeRecurring)
                    .HasPrincipalKey(p => p.SlotKey)
                    .HasForeignKey(d => d.SlotKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotTimeRecurring_Slot");

                entity.HasOne(d => d.TimeRecurringKeyNavigation)
                    .WithMany(p => p.SlotTimeRecurring)
                    .HasPrincipalKey(p => p.TimeRecurringKey)
                    .HasForeignKey(d => d.TimeRecurringKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SlotTimeRecurring_TimeRecurring");

                entity.HasOne(d => d.TimeTypeKeyNavigation)
                    .WithMany(p => p.SlotTimeRecurring)
                    .HasPrincipalKey(p => p.TimeTypeKey)
                    .HasForeignKey(d => d.TimeTypeKey)
                    .HasConstraintName("FK_SlotTimeRecurring_TimeType");
            });

            modelBuilder.Entity<TimeCycle>(entity =>
            {
                entity.ToTable("TimeCycle", "Entity");

                entity.HasIndex(e => e.TimeCycleKey)
                    .HasName("IX_TimeCycle_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.HasOne(d => d.TimeCycleKeyNavigation)
                    .WithMany(p => p.TimeRecurring)
                    .HasPrincipalKey(p => p.TimeCycleKey)
                    .HasForeignKey(d => d.TimeCycleKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeRecurring_TimeCycle");
            });

            modelBuilder.Entity<TimeType>(entity =>
            {
                entity.ToTable("TimeType", "Entity");

                entity.HasIndex(e => e.TimeTypeKey)
                    .HasName("IX_TimeType_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.TimeTypeDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.TimeTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Venture>(entity =>
            {
                entity.ToTable("Venture", "Entity");

                entity.HasIndex(e => e.VentureKey)
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.VentureDescription)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.VentureName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VentureSlogan)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.Venture)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venture_RecordState");
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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AppointmentKeyNavigation)
                    .WithMany(p => p.VentureAppointment)
                    .HasPrincipalKey(p => p.AppointmentKey)
                    .HasForeignKey(d => d.AppointmentKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureAppointment_Appointment");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.VentureAppointment)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureAppointment_RecordState");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureAppointment)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureAppointment_Venture");
            });

            modelBuilder.Entity<VentureDetail>(entity =>
            {
                entity.ToTable("VentureDetail", "Entity");

                entity.HasIndex(e => e.VentureDetailKey)
                    .HasName("IX_VentureDetail_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.VentureDetailKey })
                    .HasName("IX_VentureDetail_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.DetailKeyNavigation)
                    .WithMany(p => p.VentureDetail)
                    .HasPrincipalKey(p => p.DetailKey)
                    .HasForeignKey(d => d.DetailKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureDetail_Detail");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureDetail)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureDetail_Venture");
            });

            modelBuilder.Entity<VentureEntityOption>(entity =>
            {
                entity.ToTable("VentureEntityOption", "Entity");

                entity.HasIndex(e => e.VentureEntityOptionKey)
                    .HasName("IX_VentureEntityOption_Key")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntityKeyNavigation)
                    .WithMany(p => p.VentureEntityOption)
                    .HasPrincipalKey(p => p.EntityKey)
                    .HasForeignKey(d => d.EntityKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureEntityOption_Entity");

                entity.HasOne(d => d.OptionKeyNavigation)
                    .WithMany(p => p.VentureEntityOption)
                    .HasPrincipalKey(p => p.OptionKey)
                    .HasForeignKey(d => d.OptionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureEntityOption_Option");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureEntityOption)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureEntityOption_Venture");
            });

            modelBuilder.Entity<VentureLocation>(entity =>
            {
                entity.ToTable("VentureLocation", "Entity");

                entity.HasIndex(e => e.VentureLocationKey)
                    .HasName("IX_VentureLocation_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.LocationKey })
                    .HasName("IX_VentureLocation_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.LocationKeyNavigation)
                    .WithMany(p => p.VentureLocation)
                    .HasPrincipalKey(p => p.LocationKey)
                    .HasForeignKey(d => d.LocationKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureLocation_Location");

                entity.HasOne(d => d.LocationTypeKeyNavigation)
                    .WithMany(p => p.VentureLocation)
                    .HasPrincipalKey(p => p.LocationTypeKey)
                    .HasForeignKey(d => d.LocationTypeKey)
                    .HasConstraintName("FK_VentureLocation_LocationType");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.VentureLocation)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureLocation_RecordState");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureLocation)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureLocation_Venture");
            });

            modelBuilder.Entity<VentureOption>(entity =>
            {
                entity.ToTable("VentureOption", "Entity");

                entity.HasIndex(e => new { e.VentureKey, e.OptionKey })
                    .HasName("IX_VentureOption_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.OptionKeyNavigation)
                    .WithMany(p => p.VentureOption)
                    .HasPrincipalKey(p => p.OptionKey)
                    .HasForeignKey(d => d.OptionKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureOption_Option");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureOption)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureOption_Venture");
            });

            modelBuilder.Entity<VentureResource>(entity =>
            {
                entity.ToTable("VentureResource", "Entity");

                entity.HasIndex(e => e.VentureResourceKey)
                    .HasName("IX_VentureResource_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.ResourceKey })
                    .HasName("IX_VentureResource_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.VentureResource)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureResource_RecordState");

                entity.HasOne(d => d.ResourceKeyNavigation)
                    .WithMany(p => p.VentureResource)
                    .HasPrincipalKey(p => p.ResourceKey)
                    .HasForeignKey(d => d.ResourceKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureResource_Resource");

                entity.HasOne(d => d.ResourceTypeKeyNavigation)
                    .WithMany(p => p.VentureResource)
                    .HasPrincipalKey(p => p.ResourceTypeKey)
                    .HasForeignKey(d => d.ResourceTypeKey)
                    .HasConstraintName("FK_VentureResource_ResourceType");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureResource)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureResource_Venture");
            });

            modelBuilder.Entity<VentureSchedule>(entity =>
            {
                entity.ToTable("VentureSchedule", "Entity");

                entity.HasIndex(e => e.VentureScheduleKey)
                    .HasName("IX_VentureSchedule_Key")
                    .IsUnique();

                entity.HasIndex(e => new { e.VentureKey, e.ScheduleKey })
                    .HasName("IX_VentureSchedule_All")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.RecordStateKeyNavigation)
                    .WithMany(p => p.VentureSchedule)
                    .HasPrincipalKey(p => p.RecordStateKey)
                    .HasForeignKey(d => d.RecordStateKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureSchedule_RecordState");

                entity.HasOne(d => d.ScheduleKeyNavigation)
                    .WithMany(p => p.VentureSchedule)
                    .HasPrincipalKey(p => p.ScheduleKey)
                    .HasForeignKey(d => d.ScheduleKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureSchedule_Schedule");

                entity.HasOne(d => d.ScheduleTypeKeyNavigation)
                    .WithMany(p => p.VentureSchedule)
                    .HasPrincipalKey(p => p.ScheduleTypeKey)
                    .HasForeignKey(d => d.ScheduleTypeKey)
                    .HasConstraintName("FK_VentureSchedule_ScheduleType");

                entity.HasOne(d => d.VentureKeyNavigation)
                    .WithMany(p => p.VentureSchedule)
                    .HasPrincipalKey(p => p.VentureKey)
                    .HasForeignKey(d => d.VentureKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentureSchedule_Venture");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
