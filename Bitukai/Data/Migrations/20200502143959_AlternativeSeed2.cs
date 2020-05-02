using Microsoft.EntityFrameworkCore.Migrations;

namespace Bitukai.Data.Migrations
{
    public partial class AlternativeSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Component",
                keyColumn: "Id",
                keyValue: 1,
                column: "AlternativeIds",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Component",
                keyColumn: "Id",
                keyValue: 1,
                column: "AlternativeIds",
                value: null);
        }
    }
}
