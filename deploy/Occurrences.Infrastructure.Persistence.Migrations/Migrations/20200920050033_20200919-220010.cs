using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToCode.Occurrences.Infrastructure.Persistence.Migrations.Migrations
{
    public partial class _20200919220010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Occurrences");

            migrationBuilder.EnsureSchema(
                name: "Subjects");

            migrationBuilder.CreateTable(
                name: "Appointment",
                schema: "Occurrences",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    AppointmentKey = table.Column<Guid>(nullable: false),
                    AppointmentName = table.Column<string>(maxLength: 50, nullable: false),
                    AppointmentDescription = table.Column<string>(maxLength: 2000, nullable: true),
                    SlotLocationKey = table.Column<Guid>(nullable: true),
                    SlotResourceKey = table.Column<Guid>(nullable: true),
                    TimeRangeKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentEvent",
                schema: "Occurrences",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    AppointmentEventKey = table.Column<Guid>(nullable: false),
                    EventKey = table.Column<Guid>(nullable: false),
                    AppointmentKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentEvent", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                schema: "Occurrences",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    EventKey = table.Column<Guid>(nullable: false),
                    EventGroupKey = table.Column<Guid>(nullable: false),
                    EventTypeKey = table.Column<Guid>(nullable: false),
                    EventCreatorKey = table.Column<Guid>(nullable: false),
                    EventName = table.Column<string>(maxLength: 50, nullable: false),
                    EventDescription = table.Column<string>(maxLength: 250, nullable: true),
                    EventSlogan = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "EventAssociateOption",
                schema: "Occurrences",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    EventAssociateOptionKey = table.Column<Guid>(nullable: false),
                    OptionKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    EventKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAssociateOption", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "EventDetail",
                schema: "Occurrences",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    EventDetailKey = table.Column<Guid>(nullable: false),
                    EventKey = table.Column<Guid>(nullable: false),
                    DetailKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetail", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "EventGroup",
                schema: "Occurrences",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    EventGroupKey = table.Column<Guid>(nullable: false),
                    EventGroupName = table.Column<string>(maxLength: 50, nullable: false),
                    EventGroupDescription = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGroup", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "EventLocation",
                schema: "Occurrences",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    EventLocationKey = table.Column<Guid>(nullable: false),
                    EventKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocation", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "EventOption",
                schema: "Occurrences",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    EventOptionKey = table.Column<Guid>(nullable: false),
                    EventKey = table.Column<Guid>(nullable: false),
                    OptionKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOption", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "EventResource",
                schema: "Occurrences",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    EventResourceKey = table.Column<Guid>(nullable: false),
                    EventKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    ResourceTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventResource", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "EventSchedule",
                schema: "Occurrences",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    EventScheduleKey = table.Column<Guid>(nullable: false),
                    EventKey = table.Column<Guid>(nullable: false),
                    ScheduleKey = table.Column<Guid>(nullable: false),
                    ScheduleTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSchedule", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                schema: "Occurrences",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    EventTypeKey = table.Column<Guid>(nullable: false),
                    EventGroupKey = table.Column<Guid>(nullable: false),
                    EventTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    EventTypeDescription = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "AssociateAppointment",
                schema: "Subjects",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    AssociateAppointmentKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    AppointmentKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateAppointment", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureAppointment",
                schema: "Subjects",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    VentureAppointmentKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    AppointmentKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureAppointment", x => x.RowKey);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Key",
                schema: "Occurrences",
                table: "Appointment",
                column: "AppointmentKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationTime_All",
                schema: "Occurrences",
                table: "Appointment",
                columns: new[] { "SlotLocationKey", "SlotResourceKey", "TimeRangeKey" },
                unique: true,
                filter: "[SlotLocationKey] IS NOT NULL AND [SlotResourceKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentEvent_Key",
                schema: "Occurrences",
                table: "AppointmentEvent",
                column: "AppointmentEventKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentEvent_All",
                schema: "Occurrences",
                table: "AppointmentEvent",
                columns: new[] { "EventKey", "AppointmentKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventKey",
                schema: "Occurrences",
                table: "Event",
                column: "EventKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_All",
                schema: "Occurrences",
                table: "Event",
                columns: new[] { "EventGroupKey", "EventCreatorKey", "EventName" });

            migrationBuilder.CreateIndex(
                name: "IX_EventAssociateOption_Key",
                schema: "Occurrences",
                table: "EventAssociateOption",
                column: "EventAssociateOptionKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventDetail_Key",
                schema: "Occurrences",
                table: "EventDetail",
                column: "EventDetailKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventDetail_All",
                schema: "Occurrences",
                table: "EventDetail",
                columns: new[] { "EventKey", "EventDetailKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventGroup_Key",
                schema: "Occurrences",
                table: "EventGroup",
                column: "EventGroupKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventLocation_Key",
                schema: "Occurrences",
                table: "EventLocation",
                column: "EventLocationKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventLocation_All",
                schema: "Occurrences",
                table: "EventLocation",
                columns: new[] { "EventKey", "LocationKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventOption_All",
                schema: "Occurrences",
                table: "EventOption",
                columns: new[] { "EventKey", "OptionKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventResource_Key",
                schema: "Occurrences",
                table: "EventResource",
                column: "EventResourceKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventResource_All",
                schema: "Occurrences",
                table: "EventResource",
                columns: new[] { "EventKey", "ResourceKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventSchedule_Key",
                schema: "Occurrences",
                table: "EventSchedule",
                column: "EventScheduleKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventSchedule_All",
                schema: "Occurrences",
                table: "EventSchedule",
                columns: new[] { "EventKey", "ScheduleKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventType_Key",
                schema: "Occurrences",
                table: "EventType",
                column: "EventTypeKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssociateAppointment_Key",
                schema: "Subjects",
                table: "AssociateAppointment",
                column: "AssociateAppointmentKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssociateAppointment_All",
                schema: "Subjects",
                table: "AssociateAppointment",
                columns: new[] { "AssociateKey", "AppointmentKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureAppointment_Key",
                schema: "Subjects",
                table: "VentureAppointment",
                column: "VentureAppointmentKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureAppointment_All",
                schema: "Subjects",
                table: "VentureAppointment",
                columns: new[] { "VentureKey", "AppointmentKey" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "AppointmentEvent",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "EventAssociateOption",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "EventDetail",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "EventGroup",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "EventLocation",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "EventOption",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "EventResource",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "EventSchedule",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "EventType",
                schema: "Occurrences");

            migrationBuilder.DropTable(
                name: "AssociateAppointment",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "VentureAppointment",
                schema: "Subjects");
        }
    }
}
