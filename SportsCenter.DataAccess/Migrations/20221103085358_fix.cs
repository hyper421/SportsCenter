using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsCenter.DataAccess.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationOrder_Location_LocationBranch_Id",
                table: "LocationOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationOrder_LocationBranch_LocationBranchId",
                table: "LocationOrder");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "LocationOrder");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "LocationOrder",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "LocationBranchId",
                table: "LocationOrder",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationOrder_LocationBranchId",
                table: "LocationOrder",
                newName: "IX_LocationOrder_LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationOrder_Location_LocationId",
                table: "LocationOrder",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationOrder_LocationBranch_LocationBranch_Id",
                table: "LocationOrder",
                column: "LocationBranch_Id",
                principalTable: "LocationBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationOrder_Location_LocationId",
                table: "LocationOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationOrder_LocationBranch_LocationBranch_Id",
                table: "LocationOrder");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "LocationOrder",
                newName: "LocationBranchId");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "LocationOrder",
                newName: "Time");

            migrationBuilder.RenameIndex(
                name: "IX_LocationOrder_LocationId",
                table: "LocationOrder",
                newName: "IX_LocationOrder_LocationBranchId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "LocationOrder",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_LocationOrder_Location_LocationBranch_Id",
                table: "LocationOrder",
                column: "LocationBranch_Id",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationOrder_LocationBranch_LocationBranchId",
                table: "LocationOrder",
                column: "LocationBranchId",
                principalTable: "LocationBranch",
                principalColumn: "Id");
        }
    }
}
