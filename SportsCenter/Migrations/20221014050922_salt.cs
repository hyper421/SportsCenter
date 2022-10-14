using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsCenter.Migrations
{
    public partial class salt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Member_Salt",
                table: "Member",
                type: "nvarchar(Max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Member_Salt",
                table: "Member");
        }
    }
}
