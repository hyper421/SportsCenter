using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsCenter.Migrations
{
    public partial class iproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Item_Id",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Item_Id",
                table: "Products",
                column: "Item_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Item_Item_Id",
                table: "Products",
                column: "Item_Id",
                principalTable: "Item",
                principalColumn: "Item_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Item_Item_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Item_Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Item_Id",
                table: "Products");
        }
    }
}
