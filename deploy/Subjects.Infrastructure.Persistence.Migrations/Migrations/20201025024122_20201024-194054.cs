using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodToCode.Subjects.Infrastructure.Persistence.Migrations.Migrations
{
    public partial class _20201024194054 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BusinessName",
                schema: "Subjects",
                table: "Business",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BusinessName",
                schema: "Subjects",
                table: "Business",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
