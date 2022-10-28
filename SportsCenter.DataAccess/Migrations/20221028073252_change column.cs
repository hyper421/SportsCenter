using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsCenter.DataAccess.Migrations
{
    public partial class changecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Category");
        }
    }
}
