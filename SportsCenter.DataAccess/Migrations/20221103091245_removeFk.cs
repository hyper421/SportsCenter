using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsCenter.DataAccess.Migrations
{
    public partial class removeFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationOrder_Location_LocationId",
                table: "LocationOrder");

            migrationBuilder.DropIndex(
                name: "IX_LocationOrder_LocationId",
                table: "LocationOrder");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "LocationOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "LocationOrder",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationOrder_LocationId",
                table: "LocationOrder",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationOrder_Location_LocationId",
                table: "LocationOrder",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");
        }
    }
}
