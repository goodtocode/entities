using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Infrastructure.Persistence.Migrations.Migrations
{
    public partial class _20200820213452 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Locality");

            migrationBuilder.CreateTable(
                name: "AssociateLocation",
                schema: "Locality",
                columns: table => new
                {
                    AssociateLocationKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateLocation", x => x.AssociateLocationKey);
                });

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
                name: "GeoArea",
                schema: "Locality",
                columns: table => new
                {
                    GeoAreaKey = table.Column<Guid>(nullable: false),
                    GeodeticArea = table.Column<Geometry>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoArea", x => x.GeoAreaKey);
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
                name: "Location",
                schema: "Locality",
                columns: table => new
                {
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationName = table.Column<string>(maxLength: 50, nullable: false),
                    LocationDescription = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationKey);
                });

            migrationBuilder.CreateTable(
                name: "LocationArea",
                schema: "Locality",
                columns: table => new
                {
                    LocationAreaKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    PolygonKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationArea", x => x.LocationAreaKey);
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                schema: "Locality",
                columns: table => new
                {
                    LocationTypeKey = table.Column<Guid>(nullable: false),
                    LocationTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    LocationTypeDescription = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.LocationTypeKey);
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

            migrationBuilder.CreateTable(
                name: "ResourceLocation",
                schema: "Locality",
                columns: table => new
                {
                    ResourceLocationKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceLocation", x => x.ResourceLocationKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureLocation",
                schema: "Locality",
                columns: table => new
                {
                    VentureLocationKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureLocation", x => x.VentureLocationKey);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociateLocation_All",
                schema: "Locality",
                table: "AssociateLocation",
                columns: new[] { "AssociateKey", "LocationKey" },
                unique: true);

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
                name: "IX_Location_LocationKey",
                schema: "Locality",
                table: "Location",
                column: "LocationKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationArea_Key",
                schema: "Locality",
                table: "LocationArea",
                column: "LocationAreaKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationArea_LocationId",
                schema: "Locality",
                table: "LocationArea",
                column: "LocationKey");

            migrationBuilder.CreateIndex(
                name: "IX_LocationArea_All",
                schema: "Locality",
                table: "LocationArea",
                columns: new[] { "LocationKey", "PolygonKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationType_Key",
                schema: "Locality",
                table: "LocationType",
                column: "LocationTypeKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Polygon_Key",
                schema: "Locality",
                table: "Polygon",
                column: "PolygonKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceLocation_All",
                schema: "Locality",
                table: "ResourceLocation",
                columns: new[] { "ResourceKey", "LocationKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureLocation_Key",
                schema: "Locality",
                table: "VentureLocation",
                column: "VentureLocationKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VentureLocation_All",
                schema: "Locality",
                table: "VentureLocation",
                columns: new[] { "VentureKey", "LocationKey" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociateLocation",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "Coordinate",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "GeoArea",
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
                name: "Location",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "LocationArea",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "LocationType",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "Polygon",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "ResourceLocation",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "VentureLocation",
                schema: "Locality");
        }
    }
}
