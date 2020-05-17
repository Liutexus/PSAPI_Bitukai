using Microsoft.EntityFrameworkCore.Migrations;

namespace Bitukai.Migrations
{
    public partial class AddComponentToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Component_Categories_CategoryId",
                table: "Component");

            migrationBuilder.DropForeignKey(
                name: "FK_Component_Component_ComponentId",
                table: "Component");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Component",
                table: "Component");

            migrationBuilder.RenameTable(
                name: "Component",
                newName: "Components");

            migrationBuilder.RenameIndex(
                name: "IX_Component_ComponentId",
                table: "Components",
                newName: "IX_Components_ComponentId");

            migrationBuilder.RenameIndex(
                name: "IX_Component_CategoryId",
                table: "Components",
                newName: "IX_Components_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Components",
                table: "Components",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Categories_CategoryId",
                table: "Components",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Components_ComponentId",
                table: "Components",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Categories_CategoryId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Components_Components_ComponentId",
                table: "Components");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Components",
                table: "Components");

            migrationBuilder.RenameTable(
                name: "Components",
                newName: "Component");

            migrationBuilder.RenameIndex(
                name: "IX_Components_ComponentId",
                table: "Component",
                newName: "IX_Component_ComponentId");

            migrationBuilder.RenameIndex(
                name: "IX_Components_CategoryId",
                table: "Component",
                newName: "IX_Component_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Component",
                table: "Component",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Categories_CategoryId",
                table: "Component",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Component_Component_ComponentId",
                table: "Component",
                column: "ComponentId",
                principalTable: "Component",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
