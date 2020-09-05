using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToCode.Subjects.Infrastructure.Persistence.Migrations.Migrations
{
    public partial class _20200904163213 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureResource",
                schema: "Subjects",
                table: "VentureResource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureOption",
                schema: "Subjects",
                table: "VentureOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureDetail",
                schema: "Subjects",
                table: "VentureDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureAssociateOption",
                schema: "Subjects",
                table: "VentureAssociateOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venture",
                schema: "Subjects",
                table: "Venture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceType",
                schema: "Subjects",
                table: "ResourceType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourcePerson",
                schema: "Subjects",
                table: "ResourcePerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceItem",
                schema: "Subjects",
                table: "ResourceItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resource",
                schema: "Subjects",
                table: "Resource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                schema: "Subjects",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionGroup",
                schema: "Subjects",
                table: "OptionGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Option",
                schema: "Subjects",
                table: "Option");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemType",
                schema: "Subjects",
                table: "ItemType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemGroup",
                schema: "Subjects",
                table: "ItemGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                schema: "Subjects",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Government",
                schema: "Subjects",
                table: "Government");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                schema: "Subjects",
                table: "Gender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailType",
                schema: "Subjects",
                table: "DetailType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Detail",
                schema: "Subjects",
                table: "Detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Business",
                schema: "Subjects",
                table: "Business");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociateOption",
                schema: "Subjects",
                table: "AssociateOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociateDetail",
                schema: "Subjects",
                table: "AssociateDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Associate",
                schema: "Subjects",
                table: "Associate");

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "VentureResource",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "VentureOption",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "VentureDetail",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "VentureAssociateOption",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "Venture",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "ResourceType",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "ResourcePerson",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "ResourceItem",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "Resource",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "Person",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "OptionGroup",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "Option",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "ItemType",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "ItemGroup",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "Item",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "Government",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "Gender",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "DetailType",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "Detail",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "Business",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "AssociateOption",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "AssociateDetail",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Subjects",
                table: "Associate",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureResource",
                schema: "Subjects",
                table: "VentureResource",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureOption",
                schema: "Subjects",
                table: "VentureOption",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureDetail",
                schema: "Subjects",
                table: "VentureDetail",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureAssociateOption",
                schema: "Subjects",
                table: "VentureAssociateOption",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venture",
                schema: "Subjects",
                table: "Venture",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceType",
                schema: "Subjects",
                table: "ResourceType",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourcePerson",
                schema: "Subjects",
                table: "ResourcePerson",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceItem",
                schema: "Subjects",
                table: "ResourceItem",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resource",
                schema: "Subjects",
                table: "Resource",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                schema: "Subjects",
                table: "Person",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionGroup",
                schema: "Subjects",
                table: "OptionGroup",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Option",
                schema: "Subjects",
                table: "Option",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemType",
                schema: "Subjects",
                table: "ItemType",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemGroup",
                schema: "Subjects",
                table: "ItemGroup",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                schema: "Subjects",
                table: "Item",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Government",
                schema: "Subjects",
                table: "Government",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                schema: "Subjects",
                table: "Gender",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailType",
                schema: "Subjects",
                table: "DetailType",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detail",
                schema: "Subjects",
                table: "Detail",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Business",
                schema: "Subjects",
                table: "Business",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociateOption",
                schema: "Subjects",
                table: "AssociateOption",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociateDetail",
                schema: "Subjects",
                table: "AssociateDetail",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Associate",
                schema: "Subjects",
                table: "Associate",
                column: "RowKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureResource",
                schema: "Subjects",
                table: "VentureResource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureOption",
                schema: "Subjects",
                table: "VentureOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureDetail",
                schema: "Subjects",
                table: "VentureDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureAssociateOption",
                schema: "Subjects",
                table: "VentureAssociateOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venture",
                schema: "Subjects",
                table: "Venture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceType",
                schema: "Subjects",
                table: "ResourceType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourcePerson",
                schema: "Subjects",
                table: "ResourcePerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceItem",
                schema: "Subjects",
                table: "ResourceItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resource",
                schema: "Subjects",
                table: "Resource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                schema: "Subjects",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionGroup",
                schema: "Subjects",
                table: "OptionGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Option",
                schema: "Subjects",
                table: "Option");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemType",
                schema: "Subjects",
                table: "ItemType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemGroup",
                schema: "Subjects",
                table: "ItemGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                schema: "Subjects",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Government",
                schema: "Subjects",
                table: "Government");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                schema: "Subjects",
                table: "Gender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailType",
                schema: "Subjects",
                table: "DetailType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Detail",
                schema: "Subjects",
                table: "Detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Business",
                schema: "Subjects",
                table: "Business");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociateOption",
                schema: "Subjects",
                table: "AssociateOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociateDetail",
                schema: "Subjects",
                table: "AssociateDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Associate",
                schema: "Subjects",
                table: "Associate");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "VentureResource");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "VentureOption");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "VentureDetail");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "VentureAssociateOption");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "Venture");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "ResourceType");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "ResourcePerson");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "ResourceItem");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "OptionGroup");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "Option");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "ItemType");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "ItemGroup");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "Government");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "Gender");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "DetailType");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "Detail");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "Business");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "AssociateOption");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "AssociateDetail");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Subjects",
                table: "Associate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureResource",
                schema: "Subjects",
                table: "VentureResource",
                column: "VentureResourceKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureOption",
                schema: "Subjects",
                table: "VentureOption",
                column: "VentureOptionKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureDetail",
                schema: "Subjects",
                table: "VentureDetail",
                column: "VentureDetailKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureAssociateOption",
                schema: "Subjects",
                table: "VentureAssociateOption",
                column: "VentureAssociateOptionKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venture",
                schema: "Subjects",
                table: "Venture",
                column: "VentureKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceType",
                schema: "Subjects",
                table: "ResourceType",
                column: "ResourceTypeKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourcePerson",
                schema: "Subjects",
                table: "ResourcePerson",
                column: "ResourcePersonKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceItem",
                schema: "Subjects",
                table: "ResourceItem",
                column: "ResourceItemKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resource",
                schema: "Subjects",
                table: "Resource",
                column: "ResourceKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                schema: "Subjects",
                table: "Person",
                column: "PersonKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionGroup",
                schema: "Subjects",
                table: "OptionGroup",
                column: "OptionGroupKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Option",
                schema: "Subjects",
                table: "Option",
                column: "OptionKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemType",
                schema: "Subjects",
                table: "ItemType",
                column: "ItemTypeKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemGroup",
                schema: "Subjects",
                table: "ItemGroup",
                column: "ItemGroupKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                schema: "Subjects",
                table: "Item",
                column: "ItemKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Government",
                schema: "Subjects",
                table: "Government",
                column: "GovernmentKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                schema: "Subjects",
                table: "Gender",
                column: "GenderKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailType",
                schema: "Subjects",
                table: "DetailType",
                column: "DetailTypeKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detail",
                schema: "Subjects",
                table: "Detail",
                column: "DetailKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Business",
                schema: "Subjects",
                table: "Business",
                column: "BusinessKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociateOption",
                schema: "Subjects",
                table: "AssociateOption",
                column: "AssociateOptionKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociateDetail",
                schema: "Subjects",
                table: "AssociateDetail",
                column: "AssociateDetailKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Associate",
                schema: "Subjects",
                table: "Associate",
                column: "AssociateKey");
        }
    }
}
