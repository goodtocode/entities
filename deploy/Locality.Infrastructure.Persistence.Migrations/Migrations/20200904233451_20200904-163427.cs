using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Infrastructure.Persistence.Migrations.Migrations
{
    public partial class _20200904163427 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinate",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "GeoArea",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "GeoLocation",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "Line",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "Polygon",
                schema: "Locality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureLocation",
                schema: "Locality",
                table: "VentureLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceLocation",
                schema: "Locality",
                table: "ResourceLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationType",
                schema: "Locality",
                table: "LocationType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationArea",
                schema: "Locality",
                table: "LocationArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                schema: "Locality",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LatLong",
                schema: "Locality",
                table: "LatLong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeoDistance",
                schema: "Locality",
                table: "GeoDistance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociateLocation",
                schema: "Locality",
                table: "AssociateLocation");

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Locality",
                table: "VentureLocation",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Locality",
                table: "ResourceLocation",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Locality",
                table: "LocationType",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Locality",
                table: "LocationArea",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Locality",
                table: "Location",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Locality",
                table: "LatLong",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Locality",
                table: "GeoDistance",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RowKey",
                schema: "Locality",
                table: "AssociateLocation",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureLocation",
                schema: "Locality",
                table: "VentureLocation",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceLocation",
                schema: "Locality",
                table: "ResourceLocation",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationType",
                schema: "Locality",
                table: "LocationType",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationArea",
                schema: "Locality",
                table: "LocationArea",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                schema: "Locality",
                table: "Location",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LatLong",
                schema: "Locality",
                table: "LatLong",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeoDistance",
                schema: "Locality",
                table: "GeoDistance",
                column: "RowKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociateLocation",
                schema: "Locality",
                table: "AssociateLocation",
                column: "RowKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VentureLocation",
                schema: "Locality",
                table: "VentureLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResourceLocation",
                schema: "Locality",
                table: "ResourceLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationType",
                schema: "Locality",
                table: "LocationType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationArea",
                schema: "Locality",
                table: "LocationArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                schema: "Locality",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LatLong",
                schema: "Locality",
                table: "LatLong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeoDistance",
                schema: "Locality",
                table: "GeoDistance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssociateLocation",
                schema: "Locality",
                table: "AssociateLocation");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Locality",
                table: "VentureLocation");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Locality",
                table: "ResourceLocation");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Locality",
                table: "LocationType");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Locality",
                table: "LocationArea");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Locality",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Locality",
                table: "LatLong");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Locality",
                table: "GeoDistance");

            migrationBuilder.DropColumn(
                name: "RowKey",
                schema: "Locality",
                table: "AssociateLocation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentureLocation",
                schema: "Locality",
                table: "VentureLocation",
                column: "VentureLocationKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResourceLocation",
                schema: "Locality",
                table: "ResourceLocation",
                column: "ResourceLocationKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationType",
                schema: "Locality",
                table: "LocationType",
                column: "LocationTypeKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationArea",
                schema: "Locality",
                table: "LocationArea",
                column: "LocationAreaKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                schema: "Locality",
                table: "Location",
                column: "LocationKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LatLong",
                schema: "Locality",
                table: "LatLong",
                column: "LatLongKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeoDistance",
                schema: "Locality",
                table: "GeoDistance",
                column: "GeoDistanceKey");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssociateLocation",
                schema: "Locality",
                table: "AssociateLocation",
                column: "AssociateLocationKey");

            migrationBuilder.CreateTable(
                name: "Coordinate",
                schema: "Locality",
                columns: table => new
                {
                    CoordinateKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoordinatePoint = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinate", x => x.CoordinateKey);
                });

            migrationBuilder.CreateTable(
                name: "GeoArea",
                schema: "Locality",
                columns: table => new
                {
                    GeoAreaKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeodeticArea = table.Column<Geometry>(type: "geometry", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoArea", x => x.GeoAreaKey);
                });

            migrationBuilder.CreateTable(
                name: "GeoLocation",
                schema: "Locality",
                columns: table => new
                {
                    GeoLocationKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Elevation = table.Column<Point>(type: "geography", nullable: true),
                    LatLongKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoLocation", x => x.GeoLocationKey);
                });

            migrationBuilder.CreateTable(
                name: "Line",
                schema: "Locality",
                columns: table => new
                {
                    LineKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndPoint = table.Column<Point>(type: "geography", nullable: true),
                    StartPoint = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.LineKey);
                });

            migrationBuilder.CreateTable(
                name: "Polygon",
                schema: "Locality",
                columns: table => new
                {
                    PolygonKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolygonSequence = table.Column<Geometry>(type: "geometry", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polygon", x => x.PolygonKey);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coordinate_Key",
                schema: "Locality",
                table: "Coordinate",
                column: "CoordinateKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeoArea_Key",
                schema: "Locality",
                table: "GeoArea",
                column: "GeoAreaKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeoLocation_Key",
                schema: "Locality",
                table: "GeoLocation",
                column: "GeoLocationKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Line_Key",
                schema: "Locality",
                table: "Line",
                column: "LineKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Polygon_Key",
                schema: "Locality",
                table: "Polygon",
                column: "PolygonKey",
                unique: true);
        }
    }
}
