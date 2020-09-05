using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToCode.Occurrences.Infrastructure.Persistence.Migrations.Migrations
{
    public partial class _20200904163323 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureAppointment",
                schema: "Subjects",
                table: "VentureAppointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociateAppointment",
                schema: "Subjects",
                table: "AssociateAppointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventType",
                schema: "Occurrences",
                table: "EventType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventSchedule",
                schema: "Occurrences",
                table: "EventSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventResource",
                schema: "Occurrences",
                table: "EventResource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventOption",
                schema: "Occurrences",
                table: "EventOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventLocation",
                schema: "Occurrences",
                table: "EventLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventGroup",
                schema: "Occurrences",
                table: "EventGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventDetail",
                schema: "Occurrences",
                table: "EventDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventAssociateOption",
                schema: "Occurrences",
                table: "EventAssociateOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                schema: "Occurrences",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentEvent",
                schema: "Occurrences",
                table: "AppointmentEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                schema: "Occurrences",
                table: "Appointment");

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "VentureAppointment",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "AssociateAppointment",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventType",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventSchedule",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventResource",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventOption",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventLocation",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventGroup",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventDetail",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventAssociateOption",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "EventSlogan",
                schema: "Occurrences",
                table: "Event",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Occurrences",
                table: "Event",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Occurrences",
                table: "AppointmentEvent",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Occurrences",
                table: "Appointment",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureAppointment",
                schema: "Subjects",
                table: "VentureAppointment",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociateAppointment",
                schema: "Subjects",
                table: "AssociateAppointment",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventType",
                schema: "Occurrences",
                table: "EventType",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventSchedule",
                schema: "Occurrences",
                table: "EventSchedule",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventResource",
                schema: "Occurrences",
                table: "EventResource",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventOption",
                schema: "Occurrences",
                table: "EventOption",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventLocation",
                schema: "Occurrences",
                table: "EventLocation",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventGroup",
                schema: "Occurrences",
                table: "EventGroup",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventDetail",
                schema: "Occurrences",
                table: "EventDetail",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventAssociateOption",
                schema: "Occurrences",
                table: "EventAssociateOption",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                schema: "Occurrences",
                table: "Event",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentEvent",
                schema: "Occurrences",
                table: "AppointmentEvent",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                schema: "Occurrences",
                table: "Appointment",
                column: "RowKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureAppointment",
                schema: "Subjects",
                table: "VentureAppointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociateAppointment",
                schema: "Subjects",
                table: "AssociateAppointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventType",
                schema: "Occurrences",
                table: "EventType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventSchedule",
                schema: "Occurrences",
                table: "EventSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventResource",
                schema: "Occurrences",
                table: "EventResource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventOption",
                schema: "Occurrences",
                table: "EventOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventLocation",
                schema: "Occurrences",
                table: "EventLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventGroup",
                schema: "Occurrences",
                table: "EventGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventDetail",
                schema: "Occurrences",
                table: "EventDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventAssociateOption",
                schema: "Occurrences",
                table: "EventAssociateOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                schema: "Occurrences",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentEvent",
                schema: "Occurrences",
                table: "AppointmentEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                schema: "Occurrences",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "VentureAppointment");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "AssociateAppointment");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventType");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventSchedule");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventResource");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventOption");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventLocation");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventGroup");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventDetail");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Occurrences",
                table: "EventAssociateOption");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Occurrences",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Occurrences",
                table: "AppointmentEvent");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Occurrences",
                table: "Appointment");

            migrationBuilder.AlterColumn<string>(
                name: "EventSlogan",
                schema: "Occurrences",
                table: "Event",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureAppointment",
                schema: "Subjects",
                table: "VentureAppointment",
                column: "VentureAppointmentKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociateAppointment",
                schema: "Subjects",
                table: "AssociateAppointment",
                column: "AssociateAppointmentKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventType",
                schema: "Occurrences",
                table: "EventType",
                column: "EventTypeKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventSchedule",
                schema: "Occurrences",
                table: "EventSchedule",
                column: "EventScheduleKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventResource",
                schema: "Occurrences",
                table: "EventResource",
                column: "EventResourceKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventOption",
                schema: "Occurrences",
                table: "EventOption",
                column: "EventOptionKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventLocation",
                schema: "Occurrences",
                table: "EventLocation",
                column: "EventLocationKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventGroup",
                schema: "Occurrences",
                table: "EventGroup",
                column: "EventGroupKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventDetail",
                schema: "Occurrences",
                table: "EventDetail",
                column: "EventDetailKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventAssociateOption",
                schema: "Occurrences",
                table: "EventAssociateOption",
                column: "EventAssociateOptionKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                schema: "Occurrences",
                table: "Event",
                column: "EventKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentEvent",
                schema: "Occurrences",
                table: "AppointmentEvent",
                column: "AppointmentEventKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                schema: "Occurrences",
                table: "Appointment",
                column: "AppointmentKey");
        }
    }
}
