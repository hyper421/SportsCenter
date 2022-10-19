using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsCenter.Migrations
{
    public partial class _123456 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationOrder_EndDateTime",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "LocationOrder_StartDateTime",
                table: "Order",
                newName: "LocationOrder_DateTime");

            migrationBuilder.AddColumn<string>(
                name: "Products_Target",
                table: "Products",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Products_img",
                table: "Products",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Products_Target",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Products_img",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "LocationOrder_DateTime",
                table: "Order",
                newName: "LocationOrder_StartDateTime");

            migrationBuilder.AddColumn<string>(
                name: "LocationOrder_EndDateTime",
                table: "Order",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
