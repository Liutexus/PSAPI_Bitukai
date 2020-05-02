using Microsoft.EntityFrameworkCore.Migrations;

namespace Bitukai.Data.Migrations
{
    public partial class Components : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    ComponentId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    FormFactor = table.Column<string>(nullable: true),
                    ChipSet = table.Column<string>(nullable: true),
                    MemoryType = table.Column<string>(nullable: true),
                    MemorySlots = table.Column<byte>(nullable: true),
                    CpuSocket = table.Column<string>(nullable: true),
                    PowerSupply_FormFactor = table.Column<string>(nullable: true),
                    Wattage = table.Column<int>(nullable: true),
                    Efficiency = table.Column<string>(nullable: true),
                    Modularity = table.Column<int>(nullable: true),
                    Socket = table.Column<string>(nullable: true),
                    Tdp = table.Column<double>(nullable: true),
                    CoreCount = table.Column<byte>(nullable: true),
                    CoreClockGhz = table.Column<float>(nullable: true),
                    IntegratedGpu = table.Column<string>(nullable: true),
                    CapacityGb = table.Column<int>(nullable: true),
                    ModuleCount = table.Column<byte>(nullable: true),
                    DdrType = table.Column<string>(nullable: true),
                    SpeedMhz = table.Column<int>(nullable: true),
                    CasLatency = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Storage_CapacityGb = table.Column<int>(nullable: true),
                    Storage_Type = table.Column<string>(nullable: true),
                    CacheMb = table.Column<int>(nullable: true),
                    Storage_FormFactor = table.Column<string>(nullable: true),
                    Interface = table.Column<string>(nullable: true),
                    VideoCard_ChipSet = table.Column<string>(nullable: true),
                    VideoCard_MemoryType = table.Column<string>(nullable: true),
                    MemoryGb = table.Column<int>(nullable: true),
                    CoreClockMhz = table.Column<int>(nullable: true),
                    VideoCard_Interface = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Component_Component_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Component",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Component_ComponentId",
                table: "Component",
                column: "ComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Component");
        }
    }
}
