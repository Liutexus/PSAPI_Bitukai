using Microsoft.EntityFrameworkCore.Migrations;

namespace Bitukai.Migrations
{
    public partial class ComponentPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Components",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 50.23m);

            migrationBuilder.UpdateData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 123.23m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Components");
        }
    }
}
