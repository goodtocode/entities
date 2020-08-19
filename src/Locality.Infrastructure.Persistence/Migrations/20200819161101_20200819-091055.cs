using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Infrastructure.Persistence.Migrations
{
    public partial class _20200819091055 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_GeoArea_Key",
                schema: "Locality",
                table: "GeoArea",
                column: "GeoAreaKey",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeoArea",
                schema: "Locality");
        }
    }
}
