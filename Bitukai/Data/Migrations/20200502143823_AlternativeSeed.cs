using Microsoft.EntityFrameworkCore.Migrations;

namespace Bitukai.Data.Migrations
{
    public partial class AlternativeSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlternativeIds",
                table: "Component",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Component",
                keyColumn: "Id",
                keyValue: 2,
                column: "AlternativeIds",
                value: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternativeIds",
                table: "Component");
        }
    }
}
