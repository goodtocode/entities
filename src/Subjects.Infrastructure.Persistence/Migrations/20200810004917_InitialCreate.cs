using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToCode.Shared.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Subjects");

            migrationBuilder.CreateTable(
                name: "Business",
                schema: "Subjects",
                columns: table => new
                {
                    BusinessKey = table.Column<Guid>(nullable: false),
                    BusinessName = table.Column<string>(maxLength: 50, nullable: false),
                    TaxNumber = table.Column<string>(maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessKey);
                });

            migrationBuilder.CreateTable(
                name: "Detail",
                schema: "Subjects",
                columns: table => new
                {
                    DetailKey = table.Column<Guid>(nullable: false),
                    DetailTypeKey = table.Column<Guid>(nullable: false),
                    DetailData = table.Column<string>(maxLength: 2000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.DetailKey);
                });

            migrationBuilder.CreateTable(
                name: "DetailType",
                schema: "Subjects",
                columns: table => new
                {
                    DetailTypeKey = table.Column<Guid>(nullable: false),
                    DetailTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    DetailTypeDescription = table.Column<string>(maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailType", x => x.DetailTypeKey);
                });

            migrationBuilder.CreateTable(
                name: "Associate",
                schema: "Subjects",
                columns: table => new
                {
                    AssociateKey = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.AssociateKey);
                });

            migrationBuilder.CreateTable(
                name: "AssociateAppointment",
                schema: "Subjects",
                columns: table => new
                {
                    AssociateAppointmentKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    AppointmentKey = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateAppointment", x => x.AssociateAppointmentKey);
                });

            migrationBuilder.CreateTable(
                name: "AssociateDetail",
                schema: "Subjects",
                columns: table => new
                {
                    AssociateDetailKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    DetailKey = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateDetail", x => x.AssociateDetailKey);
                });

            migrationBuilder.CreateTable(
                name: "AssociateLocation",
                schema: "Subjects",
                columns: table => new
                {
                    AssociateLocationKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationTypeKey = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateLocation", x => x.AssociateLocationKey);
                });

            migrationBuilder.CreateTable(
                name: "AssociateOption",
                schema: "Subjects",
                columns: table => new
                {
                    AssociateOptionKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    OptionKey = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateOption", x => x.AssociateOptionKey);
                });

            migrationBuilder.CreateTable(
                name: "AssociateTimeRecurring",
                schema: "Subjects",
                columns: table => new
                {
                    AssociateTimeRecurringKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    DayName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateTimeRecurring", x => x.AssociateTimeRecurringKey);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                schema: "Subjects",
                columns: table => new
                {
                    GenderKey = table.Column<Guid>(nullable: false),
                    GenderName = table.Column<string>(maxLength: 50, nullable: false),
                    GenderCode = table.Column<string>(maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderKey);
                    table.CheckConstraint("CC_Gender_GenderCode", "GenderCode in ('M', 'F', 'N/A', 'U/K')");
                });

            migrationBuilder.CreateTable(
                name: "Government",
                schema: "Subjects",
                columns: table => new
                {
                    GovernmentKey = table.Column<Guid>(nullable: false),
                    GovernmentName = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Government", x => x.GovernmentKey);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "Subjects",
                columns: table => new
                {
                    ItemKey = table.Column<Guid>(nullable: false),
                    ItemName = table.Column<string>(maxLength: 50, nullable: false),
                    ItemDescription = table.Column<string>(maxLength: 2000, nullable: false),
                    ItemTypeKey = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemKey);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroup",
                schema: "Subjects",
                columns: table => new
                {
                    ItemGroupKey = table.Column<Guid>(nullable: false),
                    ItemGroupName = table.Column<string>(maxLength: 50, nullable: false),
                    ItemGroupDescription = table.Column<string>(maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroup", x => x.ItemGroupKey);
                });

            migrationBuilder.CreateTable(
                name: "ItemType",
                schema: "Subjects",
                columns: table => new
                {
                    ItemTypeKey = table.Column<Guid>(nullable: false),
                    ItemGroupKey = table.Column<Guid>(nullable: false),
                    ItemTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    ItemTypeDescription = table.Column<string>(maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.ItemTypeKey);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                schema: "Subjects",
                columns: table => new
                {
                    OptionKey = table.Column<Guid>(nullable: false),
                    OptionGroupKey = table.Column<Guid>(nullable: false),
                    OptionName = table.Column<string>(maxLength: 50, nullable: false),
                    OptionDescription = table.Column<string>(maxLength: 250, nullable: false),
                    OptionCode = table.Column<string>(maxLength: 10, nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.OptionKey);
                });

            migrationBuilder.CreateTable(
                name: "OptionGroup",
                schema: "Subjects",
                columns: table => new
                {
                    OptionGroupKey = table.Column<Guid>(nullable: false),
                    OptionGroupName = table.Column<string>(maxLength: 50, nullable: false),
                    OptionGroupDescription = table.Column<string>(maxLength: 250, nullable: false),
                    OptionGroupCode = table.Column<string>(maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionGroup", x => x.OptionGroupKey);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Subjects",
                columns: table => new
                {
                    PersonKey = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    GenderCode = table.Column<string>(maxLength: 3, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonKey);
                    table.CheckConstraint("CC_Person_GenderCode", "GenderCode in ('M', 'F', 'N/A', 'U/K')");
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                schema: "Subjects",
                columns: table => new
                {
                    ResourceKey = table.Column<Guid>(nullable: false),
                    ResourceName = table.Column<string>(maxLength: 50, nullable: false),
                    ResourceDescription = table.Column<string>(maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceKey);
                });

            migrationBuilder.CreateTable(
                name: "ResourceItem",
                schema: "Subjects",
                columns: table => new
                {
                    ResourceItemKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    ItemKey = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceItem", x => x.ResourceItemKey);
                });

            migrationBuilder.CreateTable(
                name: "ResourcePerson",
                schema: "Subjects",
                columns: table => new
                {
                    ResourcePersonKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    PersonKey = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcePerson", x => x.ResourcePersonKey);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTimeRecurring",
                schema: "Subjects",
                columns: table => new
                {
                    ResourceTimeRecurringKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    TimeRecurringKey = table.Column<Guid>(nullable: false),
                    DayName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeName = table.Column<string>(maxLength: 50, nullable: false),
                    TimeTypeKey = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTimeRecurring", x => x.ResourceTimeRecurringKey);
                });

            migrationBuilder.CreateTable(
                name: "ResourceType",
                schema: "Subjects",
                columns: table => new
                {
                    ResourceTypeKey = table.Column<Guid>(nullable: false),
                    ResourceTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    ResourceTypeDescription = table.Column<string>(maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceType", x => x.ResourceTypeKey);
                });

            migrationBuilder.CreateTable(
                name: "Venture",
                schema: "Subjects",
                columns: table => new
                {
                    VentureKey = table.Column<Guid>(nullable: false),
                    VentureGroupKey = table.Column<Guid>(nullable: true),
                    VentureTypeKey = table.Column<Guid>(nullable: true),
                    VentureName = table.Column<string>(maxLength: 50, nullable: false),
                    VentureDescription = table.Column<string>(maxLength: 250, nullable: false),
                    VentureSlogan = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venture", x => x.VentureKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureAppointment",
                schema: "Subjects",
                columns: table => new
                {
                    VentureAppointmentKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    AppointmentKey = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureAppointment", x => x.VentureAppointmentKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureDetail",
                schema: "Subjects",
                columns: table => new
                {
                    VentureDetailKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    DetailKey = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureDetail", x => x.VentureDetailKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureAssociateOption",
                schema: "Subjects",
                columns: table => new
                {
                    VentureAssociateOptionKey = table.Column<Guid>(nullable: false),
                    OptionKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureAssociateOption", x => x.VentureAssociateOptionKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureLocation",
                schema: "Subjects",
                columns: table => new
                {
                    VentureLocationKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationTypeKey = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureLocation", x => x.VentureLocationKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureOption",
                schema: "Subjects",
                columns: table => new
                {
                    VentureOptionKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    OptionKey = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureOption", x => x.VentureOptionKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureResource",
                schema: "Subjects",
                columns: table => new
                {
                    VentureResourceKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    ResourceTypeKey = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureResource", x => x.VentureResourceKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureSchedule",
                schema: "Subjects",
                columns: table => new
                {
                    VentureScheduleKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    ScheduleKey = table.Column<Guid>(nullable: false),
                    ScheduleTypeKey = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureSchedule", x => x.VentureScheduleKey);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_Key",
                schema: "Subjects",
                table: "Business",
                column: "BusinessKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Key",
                schema: "Subjects",
                table: "Detail",
                column: "DetailKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailType_Key",
                schema: "Subjects",
                table: "DetailType",
                column: "DetailTypeKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssociateLocation_Entity",
                schema: "Subjects",
                table: "Associate",
                column: "AssociateKey",
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
                name: "IX_AssociateDetail_Key",
                schema: "Subjects",
                table: "AssociateDetail",
                column: "AssociateDetailKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssociateDetail_All",
                schema: "Subjects",
                table: "AssociateDetail",
                columns: new[] { "AssociateKey", "AssociateDetailKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssociateLocation_All",
                schema: "Subjects",
                table: "AssociateLocation",
                columns: new[] { "AssociateKey", "LocationKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssociateOption_All",
                schema: "Subjects",
                table: "AssociateOption",
                columns: new[] { "AssociateKey", "OptionKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssociateTimeRecurring_Key",
                schema: "Subjects",
                table: "AssociateTimeRecurring",
                column: "AssociateTimeRecurringKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssociateTimeRecurring_All",
                schema: "Subjects",
                table: "AssociateTimeRecurring",
                columns: new[] { "AssociateKey", "TimeRecurringKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gender_Code",
                schema: "Subjects",
                table: "Gender",
                column: "GenderCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gender_Key",
                schema: "Subjects",
                table: "Gender",
                column: "GenderKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Government_Entity",
                schema: "Subjects",
                table: "Government",
                column: "GovernmentKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemKey",
                schema: "Subjects",
                table: "Item",
                column: "ItemKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemGroup_Key",
                schema: "Subjects",
                table: "ItemGroup",
                column: "ItemGroupKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemType_Key",
                schema: "Subjects",
                table: "ItemType",
                column: "ItemTypeKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Option_OptionKey",
                schema: "Subjects",
                table: "Option",
                column: "OptionKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Option_OptionCode",
                schema: "Subjects",
                table: "Option",
                columns: new[] { "OptionGroupKey", "OptionCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Option_OptionGroupCode",
                schema: "Subjects",
                table: "OptionGroup",
                column: "OptionGroupCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Option_OptionGroupKey",
                schema: "Subjects",
                table: "OptionGroup",
                column: "OptionGroupKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_Entity",
                schema: "Subjects",
                table: "Person",
                column: "PersonKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_All",
                schema: "Subjects",
                table: "Person",
                columns: new[] { "FirstName", "MiddleName", "LastName", "BirthDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Resource_ResourceKey",
                schema: "Subjects",
                table: "Resource",
                column: "ResourceKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceItem_Item",
                schema: "Subjects",
                table: "ResourceItem",
                column: "ItemKey");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceItem_Key",
                schema: "Subjects",
                table: "ResourceItem",
                column: "ResourceItemKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceItem_Resource",
                schema: "Subjects",
                table: "ResourceItem",
                column: "ResourceKey");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceItem_All",
                schema: "Subjects",
                table: "ResourceItem",
                columns: new[] { "ResourceKey", "ItemKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_Person",
                schema: "Subjects",
                table: "ResourcePerson",
                column: "PersonKey");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_Resource",
                schema: "Subjects",
                table: "ResourcePerson",
                column: "ResourceKey");

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_Key",
                schema: "Subjects",
                table: "ResourcePerson",
                column: "ResourcePersonKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourcePerson_All",
                schema: "Subjects",
                table: "ResourcePerson",
                columns: new[] { "ResourceKey", "PersonKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTimeRecurring_Resource",
                schema: "Subjects",
                table: "ResourceTimeRecurring",
                column: "ResourceTimeRecurringKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTimeRecurring_All",
                schema: "Subjects",
                table: "ResourceTimeRecurring",
                columns: new[] { "ResourceKey", "TimeRecurringKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceType_Key",
                schema: "Subjects",
                table: "ResourceType",
                column: "ResourceTypeKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venture_VentureKey",
                schema: "Subjects",
                table: "Venture",
                column: "VentureKey",
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

            migrationBuilder.CreateIndex(
                name: "IX_VentureDetail_Key",
                schema: "Subjects",
                table: "VentureDetail",
                column: "VentureDetailKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureDetail_All",
                schema: "Subjects",
                table: "VentureDetail",
                columns: new[] { "VentureKey", "VentureDetailKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureAssociateOption_Key",
                schema: "Subjects",
                table: "VentureAssociateOption",
                column: "VentureAssociateOptionKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureLocation_Key",
                schema: "Subjects",
                table: "VentureLocation",
                column: "VentureLocationKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureLocation_All",
                schema: "Subjects",
                table: "VentureLocation",
                columns: new[] { "VentureKey", "LocationKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureOption_All",
                schema: "Subjects",
                table: "VentureOption",
                columns: new[] { "VentureKey", "OptionKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureResource_Key",
                schema: "Subjects",
                table: "VentureResource",
                column: "VentureResourceKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureResource_All",
                schema: "Subjects",
                table: "VentureResource",
                columns: new[] { "VentureKey", "ResourceKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureSchedule_Key",
                schema: "Subjects",
                table: "VentureSchedule",
                column: "VentureScheduleKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureSchedule_All",
                schema: "Subjects",
                table: "VentureSchedule",
                columns: new[] { "VentureKey", "ScheduleKey" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Business",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "Detail",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "DetailType",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "Associate",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "AssociateAppointment",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "AssociateDetail",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "AssociateLocation",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "AssociateOption",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "AssociateTimeRecurring",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "Government",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "ItemGroup",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "ItemType",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "Option",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "OptionGroup",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "Resource",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "ResourceItem",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "ResourcePerson",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "ResourceTimeRecurring",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "ResourceType",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "Venture",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "VentureAppointment",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "VentureDetail",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "VentureAssociateOption",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "VentureLocation",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "VentureOption",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "VentureResource",
                schema: "Subjects");

            migrationBuilder.DropTable(
                name: "VentureSchedule",
                schema: "Subjects");
        }
    }
}
