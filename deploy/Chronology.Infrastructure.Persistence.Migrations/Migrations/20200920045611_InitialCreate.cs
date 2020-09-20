using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToCode.Chronology.Infrastructure.Persistence.Migrations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Chronology");

            migrationBuilder.CreateTable(
                name: "AssociateSchedule",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    AssociateScheduleKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    ScheduleKey = table.Column<Guid>(nullable: false),
                    ScheduleTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateSchedule", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "AssociateTimeRecurring",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    AssociateTimeRecurringKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    DayName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateTimeRecurring", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "LocationTimeRecurring",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    LocationTimeRecurringKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    DayName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTimeRecurring", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "ResourceSchedule",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    ResourceScheduleKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    ScheduleKey = table.Column<Guid>(nullable: false),
                    ScheduleTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceSchedule", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTimeRecurring",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    ResourceTimeRecurringKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    DayName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTimeRecurring", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    ScheduleKey = table.Column<Guid>(nullable: false),
                    ScheduleName = table.Column<string>(maxLength: 50, nullable: false),
                    ScheduleDescription = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleSlot",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    ScheduleSlotKey = table.Column<Guid>(nullable: false),
                    ScheduleKey = table.Column<Guid>(nullable: false),
                    SlotKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleSlot", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleType",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    ScheduleTypeKey = table.Column<Guid>(nullable: false),
                    ScheduleTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    ScheduleTypeDescription = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleType", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "Slot",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    SlotKey = table.Column<Guid>(nullable: false),
                    SlotName = table.Column<string>(maxLength: 50, nullable: false),
                    SlotDescription = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "SlotLocation",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    SlotLocationKey = table.Column<Guid>(nullable: false),
                    SlotKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotLocation", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "SlotResource",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    SlotResourceKey = table.Column<Guid>(nullable: false),
                    SlotKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    ResourceTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotResource", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "SlotTimeRange",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    SlotTimeRangeKey = table.Column<Guid>(nullable: false),
                    SlotKey = table.Column<Guid>(nullable: false),
                    TimeRangeKey = table.Column<Guid>(nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotTimeRange", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "SlotTimeRecurring",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    SlotTimeRecurringKey = table.Column<Guid>(nullable: false),
                    SlotKey = table.Column<Guid>(nullable: false),
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotTimeRecurring", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "TimeCycle",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    TimeCycleKey = table.Column<Guid>(nullable: false),
                    TimeCycleName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeCycleDescription = table.Column<string>(maxLength: 250, nullable: true),
                    Days = table.Column<int>(nullable: false),
                    Interval = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeCycle", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "TimeRange",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    TimeRangeKey = table.Column<Guid>(nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeRange", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "TimeRecurring",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_TimeRecurring", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "TimeType",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    TimeTypeKey = table.Column<Guid>(nullable: false),
                    TimeTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeTypeDescription = table.Column<string>(maxLength: 250, nullable: true),
                    TimeBehavior = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeType", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureSchedule",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    VentureScheduleKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    ScheduleKey = table.Column<Guid>(nullable: false),
                    ScheduleTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureSchedule", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureTimeRecurring",
                schema: "Chronology",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    VentureTimeRecurringKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    DayName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureTimeRecurring", x => x.RowKey);
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
                name: "IX_Schedule_ScheduleKey",
                schema: "Chronology",
                table: "Schedule",
                column: "ScheduleKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSlot_Schedule",
                schema: "Chronology",
                table: "ScheduleSlot",
                column: "ScheduleKey");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSlot_Key",
                schema: "Chronology",
                table: "ScheduleSlot",
                column: "ScheduleSlotKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSlot_Slot",
                schema: "Chronology",
                table: "ScheduleSlot",
                column: "SlotKey");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleSlot_All",
                schema: "Chronology",
                table: "ScheduleSlot",
                columns: new[] { "SlotKey", "ScheduleKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleType_Key",
                schema: "Chronology",
                table: "ScheduleType",
                column: "ScheduleTypeKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slot_SlotKey",
                schema: "Chronology",
                table: "Slot",
                column: "SlotKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotLocation_Slot",
                schema: "Chronology",
                table: "SlotLocation",
                column: "SlotKey");

            migrationBuilder.CreateIndex(
                name: "IX_SlotLocation_Key",
                schema: "Chronology",
                table: "SlotLocation",
                column: "SlotLocationKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotLocation_All",
                schema: "Chronology",
                table: "SlotLocation",
                columns: new[] { "SlotKey", "LocationKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotResource_Resource",
                schema: "Chronology",
                table: "SlotResource",
                column: "ResourceKey");

            migrationBuilder.CreateIndex(
                name: "IX_SlotResource_Slot",
                schema: "Chronology",
                table: "SlotResource",
                column: "SlotKey");

            migrationBuilder.CreateIndex(
                name: "IX_SlotResource_SlotResourceKey",
                schema: "Chronology",
                table: "SlotResource",
                column: "SlotResourceKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotResource_All",
                schema: "Chronology",
                table: "SlotResource",
                columns: new[] { "ResourceKey", "SlotKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotTimeRange_Slot",
                schema: "Chronology",
                table: "SlotTimeRange",
                column: "SlotKey");

            migrationBuilder.CreateIndex(
                name: "IX_SlotTime_All",
                schema: "Chronology",
                table: "SlotTimeRange",
                columns: new[] { "SlotKey", "TimeRangeKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SlotTimeRecurring_Slot",
                schema: "Chronology",
                table: "SlotTimeRecurring",
                column: "SlotKey");

            migrationBuilder.CreateIndex(
                name: "IX_SlotTime_All",
                schema: "Chronology",
                table: "SlotTimeRecurring",
                columns: new[] { "SlotKey", "TimeRecurringKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeCycle_Key",
                schema: "Chronology",
                table: "TimeCycle",
                column: "TimeCycleKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeRange_TimeRangeKey",
                schema: "Chronology",
                table: "TimeRange",
                column: "TimeRangeKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeRange_All",
                schema: "Chronology",
                table: "TimeRange",
                columns: new[] { "BeginDate", "EndDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeRecurring_TimeRecurringKey",
                schema: "Chronology",
                table: "TimeRecurring",
                column: "TimeRecurringKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeRecurring_All",
                schema: "Chronology",
                table: "TimeRecurring",
                columns: new[] { "BeginDay", "EndDay", "BeginTime", "EndTime", "Interval", "TimeCycleKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeType_Key",
                schema: "Chronology",
                table: "TimeType",
                column: "TimeTypeKey",
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
                name: "Schedule",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "ScheduleSlot",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "ScheduleType",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "Slot",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "SlotLocation",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "SlotResource",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "SlotTimeRange",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "SlotTimeRecurring",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "TimeCycle",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "TimeRange",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "TimeRecurring",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "TimeType",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "VentureSchedule",
                schema: "Chronology");

            migrationBuilder.DropTable(
                name: "VentureTimeRecurring",
                schema: "Chronology");
        }
    }
}
