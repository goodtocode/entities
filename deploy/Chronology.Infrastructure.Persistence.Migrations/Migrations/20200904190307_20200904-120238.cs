using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToCode.Chronology.Infrastructure.Persistence.Migrations.Migrations
{
    public partial class _20200904120238 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureTimeRecurring",
                schema: "Chronology",
                table: "VentureTimeRecurring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureSchedule",
                schema: "Chronology",
                table: "VentureSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeType",
                schema: "Chronology",
                table: "TimeType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeRecurring",
                schema: "Chronology",
                table: "TimeRecurring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeRange",
                schema: "Chronology",
                table: "TimeRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeCycle",
                schema: "Chronology",
                table: "TimeCycle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlotTimeRecurring",
                schema: "Chronology",
                table: "SlotTimeRecurring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlotTimeRange",
                schema: "Chronology",
                table: "SlotTimeRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlotResource",
                schema: "Chronology",
                table: "SlotResource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlotLocation",
                schema: "Chronology",
                table: "SlotLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slot",
                schema: "Chronology",
                table: "Slot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleType",
                schema: "Chronology",
                table: "ScheduleType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleSlot",
                schema: "Chronology",
                table: "ScheduleSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                schema: "Chronology",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceTimeRecurring",
                schema: "Chronology",
                table: "ResourceTimeRecurring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceSchedule",
                schema: "Chronology",
                table: "ResourceSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationTimeRecurring",
                schema: "Chronology",
                table: "LocationTimeRecurring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociateTimeRecurring",
                schema: "Chronology",
                table: "AssociateTimeRecurring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociateSchedule",
                schema: "Chronology",
                table: "AssociateSchedule");

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "VentureTimeRecurring",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "VentureSchedule",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "TimeType",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "TimeRecurring",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "TimeRange",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "TimeCycle",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "SlotTimeRecurring",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "SlotTimeRange",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "SlotResource",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "SlotLocation",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "Slot",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "ScheduleType",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "ScheduleSlot",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "Schedule",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "ResourceTimeRecurring",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "ResourceSchedule",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "LocationTimeRecurring",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "AssociateTimeRecurring",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Chronology",
                table: "AssociateSchedule",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureTimeRecurring",
                schema: "Chronology",
                table: "VentureTimeRecurring",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureSchedule",
                schema: "Chronology",
                table: "VentureSchedule",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeType",
                schema: "Chronology",
                table: "TimeType",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeRecurring",
                schema: "Chronology",
                table: "TimeRecurring",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeRange",
                schema: "Chronology",
                table: "TimeRange",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeCycle",
                schema: "Chronology",
                table: "TimeCycle",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlotTimeRecurring",
                schema: "Chronology",
                table: "SlotTimeRecurring",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlotTimeRange",
                schema: "Chronology",
                table: "SlotTimeRange",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlotResource",
                schema: "Chronology",
                table: "SlotResource",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlotLocation",
                schema: "Chronology",
                table: "SlotLocation",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slot",
                schema: "Chronology",
                table: "Slot",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleType",
                schema: "Chronology",
                table: "ScheduleType",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleSlot",
                schema: "Chronology",
                table: "ScheduleSlot",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                schema: "Chronology",
                table: "Schedule",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceTimeRecurring",
                schema: "Chronology",
                table: "ResourceTimeRecurring",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceSchedule",
                schema: "Chronology",
                table: "ResourceSchedule",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationTimeRecurring",
                schema: "Chronology",
                table: "LocationTimeRecurring",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociateTimeRecurring",
                schema: "Chronology",
                table: "AssociateTimeRecurring",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociateSchedule",
                schema: "Chronology",
                table: "AssociateSchedule",
                column: "RowKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureTimeRecurring",
                schema: "Chronology",
                table: "VentureTimeRecurring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureSchedule",
                schema: "Chronology",
                table: "VentureSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeType",
                schema: "Chronology",
                table: "TimeType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeRecurring",
                schema: "Chronology",
                table: "TimeRecurring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeRange",
                schema: "Chronology",
                table: "TimeRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeCycle",
                schema: "Chronology",
                table: "TimeCycle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlotTimeRecurring",
                schema: "Chronology",
                table: "SlotTimeRecurring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlotTimeRange",
                schema: "Chronology",
                table: "SlotTimeRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlotResource",
                schema: "Chronology",
                table: "SlotResource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SlotLocation",
                schema: "Chronology",
                table: "SlotLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slot",
                schema: "Chronology",
                table: "Slot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleType",
                schema: "Chronology",
                table: "ScheduleType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleSlot",
                schema: "Chronology",
                table: "ScheduleSlot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                schema: "Chronology",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceTimeRecurring",
                schema: "Chronology",
                table: "ResourceTimeRecurring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceSchedule",
                schema: "Chronology",
                table: "ResourceSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationTimeRecurring",
                schema: "Chronology",
                table: "LocationTimeRecurring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociateTimeRecurring",
                schema: "Chronology",
                table: "AssociateTimeRecurring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociateSchedule",
                schema: "Chronology",
                table: "AssociateSchedule");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "VentureTimeRecurring");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "VentureSchedule");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "TimeType");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "TimeRecurring");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "TimeRange");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "TimeCycle");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "SlotTimeRecurring");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "SlotTimeRange");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "SlotResource");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "SlotLocation");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "Slot");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "ScheduleType");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "ScheduleSlot");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "ResourceTimeRecurring");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "ResourceSchedule");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "LocationTimeRecurring");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "AssociateTimeRecurring");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Chronology",
                table: "AssociateSchedule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureTimeRecurring",
                schema: "Chronology",
                table: "VentureTimeRecurring",
                column: "VentureTimeRecurringKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureSchedule",
                schema: "Chronology",
                table: "VentureSchedule",
                column: "VentureScheduleKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeType",
                schema: "Chronology",
                table: "TimeType",
                column: "TimeTypeKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeRecurring",
                schema: "Chronology",
                table: "TimeRecurring",
                column: "TimeRecurringKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeRange",
                schema: "Chronology",
                table: "TimeRange",
                column: "TimeRangeKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeCycle",
                schema: "Chronology",
                table: "TimeCycle",
                column: "TimeCycleKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlotTimeRecurring",
                schema: "Chronology",
                table: "SlotTimeRecurring",
                column: "SlotTimeRecurringKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlotTimeRange",
                schema: "Chronology",
                table: "SlotTimeRange",
                column: "SlotTimeRangeKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlotResource",
                schema: "Chronology",
                table: "SlotResource",
                column: "SlotResourceKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SlotLocation",
                schema: "Chronology",
                table: "SlotLocation",
                column: "SlotLocationKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slot",
                schema: "Chronology",
                table: "Slot",
                column: "SlotKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleType",
                schema: "Chronology",
                table: "ScheduleType",
                column: "ScheduleTypeKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleSlot",
                schema: "Chronology",
                table: "ScheduleSlot",
                column: "ScheduleSlotKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                schema: "Chronology",
                table: "Schedule",
                column: "ScheduleKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceTimeRecurring",
                schema: "Chronology",
                table: "ResourceTimeRecurring",
                column: "ResourceTimeRecurringKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceSchedule",
                schema: "Chronology",
                table: "ResourceSchedule",
                column: "ResourceScheduleKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationTimeRecurring",
                schema: "Chronology",
                table: "LocationTimeRecurring",
                column: "LocationTimeRecurringKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociateTimeRecurring",
                schema: "Chronology",
                table: "AssociateTimeRecurring",
                column: "AssociateTimeRecurringKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociateSchedule",
                schema: "Chronology",
                table: "AssociateSchedule",
                column: "AssociateScheduleKey");
        }
    }
}
