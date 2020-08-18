using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToCode.Chronology.Infrastructure.Persistence.Migrations
{
    public partial class _20200817214700 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Chronology");

            migrationBuilder.EnsureSchema(
                name: "Entity");

            migrationBuilder.CreateTable(
                name: "AssociateSchedule",
                schema: "Chronology",
                columns: table => new
                {
                    AssociateScheduleKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    ScheduleKey = table.Column<Guid>(nullable: false),
                    ScheduleTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateSchedule", x => x.AssociateScheduleKey);
                });

            migrationBuilder.CreateTable(
                name: "AssociateTimeRecurring",
                schema: "Chronology",
                columns: table => new
                {
                    AssociateTimeRecurringKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    DayName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateTimeRecurring", x => x.AssociateTimeRecurringKey);
                });

            migrationBuilder.CreateTable(
                name: "LocationTimeRecurring",
                schema: "Chronology",
                columns: table => new
                {
                    LocationTimeRecurringKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    DayName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTimeRecurring", x => x.LocationTimeRecurringKey);
                });

            migrationBuilder.CreateTable(
                name: "ResourceSchedule",
                schema: "Chronology",
                columns: table => new
                {
                    ResourceScheduleKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    ScheduleKey = table.Column<Guid>(nullable: false),
                    ScheduleTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceSchedule", x => x.ResourceScheduleKey);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTimeRecurring",
                schema: "Chronology",
                columns: table => new
                {
                    ResourceTimeRecurringKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    DayName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTimeRecurring", x => x.ResourceTimeRecurringKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureSchedule",
                schema: "Chronology",
                columns: table => new
                {
                    VentureScheduleKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    ScheduleKey = table.Column<Guid>(nullable: false),
                    ScheduleTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureSchedule", x => x.VentureScheduleKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureTimeRecurring",
                schema: "Chronology",
                columns: table => new
                {
                    VentureTimeRecurringKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    DayName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureTimeRecurring", x => x.VentureTimeRecurringKey);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "Entity",
                columns: table => new
                {
                    ScheduleKey = table.Column<Guid>(nullable: false),
                    ScheduleName = table.Column<string>(maxLength: 50, nullable: false),
                    ScheduleDescription = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleKey);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleSlot",
                schema: "Entity",
                columns: table => new
                {
                    ScheduleSlotKey = table.Column<Guid>(nullable: false),
                    ScheduleKey = table.Column<Guid>(nullable: false),
                    SlotKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleSlot", x => x.ScheduleSlotKey);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleType",
                schema: "Entity",
                columns: table => new
                {
                    ScheduleTypeKey = table.Column<Guid>(nullable: false),
                    ScheduleTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    ScheduleTypeDescription = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleType", x => x.ScheduleTypeKey);
                });

            migrationBuilder.CreateTable(
                name: "Slot",
                schema: "Entity",
                columns: table => new
                {
                    SlotKey = table.Column<Guid>(nullable: false),
                    SlotName = table.Column<string>(maxLength: 50, nullable: false),
                    SlotDescription = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.SlotKey);
                });

            migrationBuilder.CreateTable(
                name: "SlotLocation",
                schema: "Entity",
                columns: table => new
                {
                    SlotLocationKey = table.Column<Guid>(nullable: false),
                    SlotKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotLocation", x => x.SlotLocationKey);
                });

            migrationBuilder.CreateTable(
                name: "SlotResource",
                schema: "Entity",
                columns: table => new
                {
                    SlotResourceKey = table.Column<Guid>(nullable: false),
                    SlotKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    ResourceTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotResource", x => x.SlotResourceKey);
                });

            migrationBuilder.CreateTable(
                name: "SlotTimeRange",
                schema: "Entity",
                columns: table => new
                {
                    SlotTimeRangeKey = table.Column<Guid>(nullable: false),
                    SlotKey = table.Column<Guid>(nullable: false),
                    TimeRangeKey = table.Column<Guid>(nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotTimeRange", x => x.SlotTimeRangeKey);
                });

            migrationBuilder.CreateTable(
                name: "SlotTimeRecurring",
                schema: "Entity",
                columns: table => new
                {
                    SlotTimeRecurringKey = table.Column<Guid>(nullable: false),
                    SlotKey = table.Column<Guid>(nullable: false),
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotTimeRecurring", x => x.SlotTimeRecurringKey);
                });

            migrationBuilder.CreateTable(
                name: "TimeCycle",
                schema: "Entity",
                columns: table => new
                {
                    TimeCycleKey = table.Column<Guid>(nullable: false),
                    TimeCycleName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeCycleDescription = table.Column<string>(maxLength: 250, nullable: false),
                    Days = table.Column<int>(nullable: false),
                    Interval = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeCycle", x => x.TimeCycleKey);
                });

            migrationBuilder.CreateTable(
                name: "TimeRange",
                schema: "Entity",
                columns: table => new
                {
                    TimeRangeKey = table.Column<Guid>(nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeRange", x => x.TimeRangeKey);
                });

            migrationBuilder.CreateTable(
                name: "TimeRecurring",
                schema: "Entity",
                columns: table => new
                {
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    BeginDay = table.Column<int>(nullable: false),
                    EndDay = table.Column<int>(nullable: false),
                    BeginTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Interval = table.Column<int>(nullable: false),
                    TimeCycleKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeRecurring", x => x.TimeRecurringKey);
                });

            migrationBuilder.CreateTable(
                name: "TimeType",
                schema: "Entity",
                columns: table => new
                {
                    TimeTypeKey = table.Column<Guid>(nullable: false),
                    TimeTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeTypeDescription = table.Column<string>(maxLength: 250, nullable: false),
                    TimeBehavior = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeType", x => x.TimeTypeKey);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociateSchedule_Key",
                schema: "Chronology",
                table: "AssociateSchedule",
                column: "AssociateScheduleKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssociateSchedule_All",
                schema: "Chronology",
                table: "AssociateSchedule",
                columns: new[] { "AssociateKey", "ScheduleKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssociateTimeRecurring_Key",
                schema: "Chronology",
                table: "AssociateTimeRecurring",
                column: "AssociateTimeRecurringKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssociateTimeRecurring_All",
                schema: "Chronology",
                table: "AssociateTimeRecurring",
                columns: new[] { "AssociateKey", "TimeRecurringKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationTimeRecurring_Location",
                schema: "Chronology",
                table: "LocationTimeRecurring",
                column: "LocationTimeRecurringKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationTimeRecurring_All",
                schema: "Chronology",
                table: "LocationTimeRecurring",
                columns: new[] { "LocationKey", "TimeRecurringKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSchedule_Key",
                schema: "Chronology",
                table: "ResourceSchedule",
                column: "ResourceScheduleKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSchedule_All",
                schema: "Chronology",
                table: "ResourceSchedule",
                columns: new[] { "ResourceKey", "ScheduleKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTimeRecurring_Resource",
                schema: "Chronology",
                table: "ResourceTimeRecurring",
                column: "ResourceTimeRecurringKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTimeRecurring_All",
                schema: "Chronology",
                table: "ResourceTimeRecurring",
                columns: new[] { "ResourceKey", "TimeRecurringKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureSchedule_Key",
                schema: "Chronology",
                table: "VentureSchedule",
                column: "VentureScheduleKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureSchedule_All",
                schema: "Chronology",
                table: "VentureSchedule",
                columns: new[] { "VentureKey", "ScheduleKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureTimeRecurring_Venture",
                schema: "Chronology",
                table: "VentureTimeRecurring",
                column: "VentureTimeRecurringKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureTimeRecurring_All",
                schema: "Chronology",
                table: "VentureTimeRecurring",
                columns: new[] { "VentureKey", "TimeRecurringKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ScheduleKey",
                schema: "Entity",
                table: "Schedule",
                column: "ScheduleKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSlot_Schedule",
                schema: "Entity",
                table: "ScheduleSlot",
                column: "ScheduleKey");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSlot_Key",
                schema: "Entity",
                table: "ScheduleSlot",
                column: "ScheduleSlotKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSlot_Slot",
                schema: "Entity",
                table: "ScheduleSlot",
                column: "SlotKey");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSlot_All",
                schema: "Entity",
                table: "ScheduleSlot",
                columns: new[] { "SlotKey", "ScheduleKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleType_Key",
                schema: "Entity",
                table: "ScheduleType",
                column: "ScheduleTypeKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slot_SlotKey",
                schema: "Entity",
                table: "Slot",
                column: "SlotKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotLocation_Slot",
                schema: "Entity",
                table: "SlotLocation",
                column: "SlotKey");

            migrationBuilder.CreateIndex(
                name: "IX_SlotLocation_Key",
                schema: "Entity",
                table: "SlotLocation",
                column: "SlotLocationKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotLocation_All",
                schema: "Entity",
                table: "SlotLocation",
                columns: new[] { "SlotKey", "LocationKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotResource_Resource",
                schema: "Entity",
                table: "SlotResource",
                column: "ResourceKey");

            migrationBuilder.CreateIndex(
                name: "IX_SlotResource_Slot",
                schema: "Entity",
                table: "SlotResource",
                column: "SlotKey");

            migrationBuilder.CreateIndex(
                name: "IX_SlotResource_SlotResourceKey",
                schema: "Entity",
                table: "SlotResource",
                column: "SlotResourceKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotResource_All",
                schema: "Entity",
                table: "SlotResource",
                columns: new[] { "ResourceKey", "SlotKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotTimeRange_Slot",
                schema: "Entity",
                table: "SlotTimeRange",
                column: "SlotKey");

            migrationBuilder.CreateIndex(
                name: "IX_SlotTime_All",
                schema: "Entity",
                table: "SlotTimeRange",
                columns: new[] { "SlotKey", "TimeRangeKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotTimeRecurring_Slot",
                schema: "Entity",
                table: "SlotTimeRecurring",
                column: "SlotKey");

            migrationBuilder.CreateIndex(
                name: "IX_SlotTime_All",
                schema: "Entity",
                table: "SlotTimeRecurring",
                columns: new[] { "SlotKey", "TimeRecurringKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeCycle_Key",
                schema: "Entity",
                table: "TimeCycle",
                column: "TimeCycleKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeRange_TimeRangeKey",
                schema: "Entity",
                table: "TimeRange",
                column: "TimeRangeKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeRange_All",
                schema: "Entity",
                table: "TimeRange",
                columns: new[] { "BeginDate", "EndDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeRecurring_TimeRecurringKey",
                schema: "Entity",
                table: "TimeRecurring",
                column: "TimeRecurringKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeRecurring_All",
                schema: "Entity",
                table: "TimeRecurring",
                columns: new[] { "BeginDay", "EndDay", "BeginTime", "EndTime", "Interval", "TimeCycleKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeType_Key",
                schema: "Entity",
                table: "TimeType",
                column: "TimeTypeKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociateSchedule",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "AssociateTimeRecurring",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "LocationTimeRecurring",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "ResourceSchedule",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "ResourceTimeRecurring",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "VentureSchedule",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "VentureTimeRecurring",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "ScheduleSlot",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "ScheduleType",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "Slot",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "SlotLocation",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "SlotResource",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "SlotTimeRange",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "SlotTimeRecurring",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "TimeCycle",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "TimeRange",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "TimeRecurring",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "TimeType",
                schema: "Entity");
        }
    }
}
