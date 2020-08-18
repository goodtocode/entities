﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToCode.Locality.Infrastructure.Persistence.Migrations
{
    public partial class _20200817222608 : Migration
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
                name: "Location",
                schema: "Locality",
                columns: table => new
                {
                    LocationKey = table.Column<Guid>(nullable: false),
                    LocationName = table.Column<string>(maxLength: 50, nullable: false),
                    LocationDescription = table.Column<string>(maxLength: 2000, nullable: false)
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
                    LocationTypeDescription = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.LocationTypeKey);
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
