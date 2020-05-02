using Microsoft.EntityFrameworkCore.Migrations;

namespace Bitukai.Data.Migrations
{
    public partial class SecondProcessorSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Component",
                columns: new[] { "Id", "ComponentId", "Discriminator", "Manufacturer", "Name", "CoreClockGhz", "CoreCount", "IntegratedGpu", "Socket", "Tdp" },
                values: new object[] { 2, null, "Processor", "AMD", "Ryzen 7 3700", 3.7f, (byte)8, "Gpu", "AM4", 3.3999999999999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Component",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
