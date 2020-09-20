using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToCode.Locality.Infrastructure.Persistence.Migrations.Migrations
{
    public partial class _20200919215906 : Migration
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
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    AssociateLocationKey = table.Column<Guid>(nullable: false),
                    AssociateKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociateLocation", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "GeoDistance",
                schema: "Locality",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    GeoDistanceKey = table.Column<Guid>(nullable: false),
                    StartLatLongKey = table.Column<Guid>(nullable: false),
                    EndLatLongKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoDistance", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "LatLong",
                schema: "Locality",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    LatLongKey = table.Column<Guid>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatLong", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Locality",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationName = table.Column<string>(maxLength: 50, nullable: false),
                    LocationDescription = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "LocationArea",
                schema: "Locality",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    LocationAreaKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    PolygonKey = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationArea", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                schema: "Locality",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    LocationTypeKey = table.Column<Guid>(nullable: false),
                    LocationTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    LocationTypeDescription = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "ResourceLocation",
                schema: "Locality",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    ResourceLocationKey = table.Column<Guid>(nullable: false),
                    ResourceKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceLocation", x => x.RowKey);
                });

            migrationBuilder.CreateTable(
                name: "VentureLocation",
                schema: "Locality",
                columns: table => new
                {
                    RowKey = table.Column<Guid>(nullable: false),
                    PartitionKey = table.Column<string>(nullable: true),
                    VentureLocationKey = table.Column<Guid>(nullable: false),
                    VentureKey = table.Column<Guid>(nullable: false),
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationTypeKey = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentureLocation", x => x.RowKey);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociateLocation_All",
                schema: "Locality",
                table: "AssociateLocation",
                columns: new[] { "AssociateKey", "LocationKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeoDistance_Key",
                schema: "Locality",
                table: "GeoDistance",
                column: "GeoDistanceKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LatLong_Key",
                schema: "Locality",
                table: "LatLong",
                column: "LatLongKey",
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
                name: "GeoDistance",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "LatLong",
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
                name: "ResourceLocation",
                schema: "Locality");

            migrationBuilder.DropTable(
                name: "VentureLocation",
                schema: "Locality");
        }
    }
}
