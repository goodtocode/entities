﻿// <auto-generated />
using System;
using GoodToCode.Occurrences.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GoodToCode.Occurrences.Infrastructure.Persistence.Migrations.Migrations
{
    [DbContext(typeof(OccurrencesDbContextDeploy))]
    partial class OccurrencesDbContextDeployModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GoodToCode.Occurrences.Models.Appointment", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppointmentDescription")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<Guid>("AppointmentKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppointmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SlotLocationKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SlotResourceKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TimeRangeKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RowKey");

                    b.HasIndex("AppointmentKey")
                        .IsUnique()
                        .HasName("IX_Appointment_Key");

                    b.HasIndex("SlotLocationKey", "SlotResourceKey", "TimeRangeKey")
                        .IsUnique()
                        .HasName("IX_LocationTime_All")
                        .HasFilter("[SlotLocationKey] IS NOT NULL AND [SlotResourceKey] IS NOT NULL");

                    b.ToTable("Appointment","Occurrences");
                });

            modelBuilder.Entity("GoodToCode.Occurrences.Models.AssociateAppointment", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppointmentKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssociateAppointmentKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssociateKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("AssociateAppointmentKey")
                        .IsUnique()
                        .HasName("IX_AssociateAppointment_Key");

                    b.HasIndex("AssociateKey", "AppointmentKey")
                        .IsUnique()
                        .HasName("IX_AssociateAppointment_All");

                    b.ToTable("AssociateAppointment","Subjects");
                });

            modelBuilder.Entity("GoodToCode.Occurrences.Models.Event", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventCreatorKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventDescription")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<Guid>("EventGroupKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("EventSlogan")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid>("EventTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("EventKey")
                        .IsUnique();

                    b.HasIndex("EventGroupKey", "EventCreatorKey", "EventName")
                        .HasName("IX_Event_All");

                    b.ToTable("Event","Occurrences");
                });

            modelBuilder.Entity("GoodToCode.Occurrences.Models.EventAppointment", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppointmentEventKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppointmentKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("AppointmentEventKey")
                        .IsUnique()
                        .HasName("IX_AppointmentEvent_Key");

                    b.HasIndex("EventKey", "AppointmentKey")
                        .IsUnique()
                        .HasName("IX_AppointmentEvent_All");

                    b.ToTable("AppointmentEvent","Occurrences");
                });

            modelBuilder.Entity("GoodToCode.Occurrences.Models.EventAssociateOption", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssociateKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventAssociateOptionKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OptionKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("EventAssociateOptionKey")
                        .IsUnique()
                        .HasName("IX_EventAssociateOption_Key");

                    b.ToTable("EventAssociateOption","Occurrences");
                });

            modelBuilder.Entity("GoodToCode.Occurrences.Models.EventDetail", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DetailKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventDetailKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("EventDetailKey")
                        .IsUnique()
                        .HasName("IX_EventDetail_Key");

                    b.HasIndex("EventKey", "EventDetailKey")
                        .IsUnique()
                        .HasName("IX_EventDetail_All");

                    b.ToTable("EventDetail","Occurrences");
                });

            modelBuilder.Entity("GoodToCode.Occurrences.Models.EventGroup", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventGroupDescription")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<Guid>("EventGroupKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventGroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("EventGroupKey")
                        .IsUnique()
                        .HasName("IX_EventGroup_Key");

                    b.ToTable("EventGroup","Occurrences");
                });

            modelBuilder.Entity("GoodToCode.Occurrences.Models.EventLocation", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventLocationKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LocationKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocationTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("EventLocationKey")
                        .IsUnique()
                        .HasName("IX_EventLocation_Key");

                    b.HasIndex("EventKey", "LocationKey")
                        .IsUnique()
                        .HasName("IX_EventLocation_All");

                    b.ToTable("EventLocation","Occurrences");
                });

            modelBuilder.Entity("GoodToCode.Occurrences.Models.EventOption", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventOptionKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OptionKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("EventKey", "OptionKey")
                        .IsUnique()
                        .HasName("IX_EventOption_All");

                    b.ToTable("EventOption","Occurrences");
                });

            modelBuilder.Entity("GoodToCode.Occurrences.Models.EventResource", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventResourceKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResourceKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResourceTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RowKey");

                    b.HasIndex("EventResourceKey")
                        .IsUnique()
                        .HasName("IX_EventResource_Key");

                    b.HasIndex("EventKey", "ResourceKey")
                        .IsUnique()
                        .HasName("IX_EventResource_All");

                    b.ToTable("EventResource","Occurrences");
                });

            modelBuilder.Entity("GoodToCode.Occurrences.Models.EventSchedule", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventScheduleKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ScheduleKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ScheduleTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RowKey");

                    b.HasIndex("EventScheduleKey")
                        .IsUnique()
                        .HasName("IX_EventSchedule_Key");

                    b.HasIndex("EventKey", "ScheduleKey")
                        .IsUnique()
                        .HasName("IX_EventSchedule_All");

                    b.ToTable("EventSchedule","Occurrences");
                });

            modelBuilder.Entity("GoodToCode.Occurrences.Models.EventType", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventGroupKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventTypeDescription")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<Guid>("EventTypeKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RowKey");

                    b.HasIndex("EventTypeKey")
                        .IsUnique()
                        .HasName("IX_EventType_Key");

                    b.ToTable("EventType","Occurrences");
                });

            modelBuilder.Entity("GoodToCode.Occurrences.Models.VentureAppointment", b =>
                {
                    b.Property<Guid>("RowKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppointmentKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PartitionKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VentureAppointmentKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VentureKey")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RowKey");

                    b.HasIndex("VentureAppointmentKey")
                        .IsUnique()
                        .HasName("IX_VentureAppointment_Key");

                    b.HasIndex("VentureKey", "AppointmentKey")
                        .IsUnique()
                        .HasName("IX_VentureAppointment_All");

                    b.ToTable("VentureAppointment","Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
