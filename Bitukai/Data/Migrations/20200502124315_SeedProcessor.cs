using Microsoft.EntityFrameworkCore.Migrations;

namespace Bitukai.Data.Migrations
{
    public partial class SeedProcessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Component",
                columns: new[] { "Id", "ComponentId", "Discriminator", "Manufacturer", "Name", "CoreClockGhz", "CoreCount", "IntegratedGpu", "Socket", "Tdp" },
                values: new object[] { 1, null, "Processor", "Intel", "Core i5-2134", 2.3f, (byte)4, "Gpu", "AM4", 3.3999999999999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
