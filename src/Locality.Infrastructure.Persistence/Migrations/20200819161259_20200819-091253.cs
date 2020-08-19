using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Infrastructure.Persistence.Migrations
{
    public partial class _20200819091253 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coordinate",
                schema: "Locality",
                columns: table => new
                {
                    CoordinateKey = table.Column<Guid>(nullable: false),
                    CoordinatePoint = table.Column<Point>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinate", x => x.CoordinateKey);
                });

            migrationBuilder.CreateTable(
                name: "GeoDistance",
                schema: "Locality",
                columns: table => new
                {
                    GeoDistanceKey = table.Column<Guid>(nullable: false),
                    StartLatLongKey = table.Column<Guid>(nullable: false),
                    EndLatLongKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoDistance", x => x.GeoDistanceKey);
                });

            migrationBuilder.CreateTable(
                name: "GeoLocation",
                schema: "Locality",
                columns: table => new
                {
                    GeoLocationKey = table.Column<Guid>(nullable: false),
                    LatLongKey = table.Column<Guid>(nullable: false),
                    Elevation = table.Column<Point>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoLocation", x => x.GeoLocationKey);
                });

            migrationBuilder.CreateTable(
                name: "LatLong",
                schema: "Locality",
                columns: table => new
                {
                    LatLongKey = table.Column<Guid>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatLong", x => x.LatLongKey);
                });

            migrationBuilder.CreateTable(
                name: "Line",
                schema: "Locality",
                columns: table => new
                {
                    LineKey = table.Column<Guid>(nullable: false),
                    StartPoint = table.Column<Point>(nullable: true),
                    EndPoint = table.Column<Point>(nullable: true)
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
                    PolygonKey = table.Column<Guid>(nullable: false),
                    PolygonSequence = table.Column<Geometry>(nullable: true)
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
                name: "IX_GeoDistance_Key",
                schema: "Locality",
                table: "GeoDistance",
                column: "GeoDistanceKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeoLocation_Key",
                schema: "Locality",
                table: "GeoLocation",
                column: "GeoLocationKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LatLong_Key",
                schema: "Locality",
                table: "LatLong",
                column: "LatLongKey",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinate",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "GeoDistance",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "GeoLocation",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "LatLong",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "Line",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "Polygon",
                schema: "Locality");
        }
    }
}
