using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsCenter.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Chat_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_Id = table.Column<int>(type: "int", nullable: false),
                    Chat_Message = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Chat_CreateDateTime = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Chat_LikeCount = table.Column<int>(type: "int", nullable: false),
                    Chat_DislikeCount = table.Column<int>(type: "int", nullable: false),
                    Chat_ValidFlag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Chat_Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Item_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Item_ValidFlag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Item_Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Location_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Location_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Location_Address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Location_partition = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Location_Phone = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Location_Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Location_Area = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Location_Price = table.Column<int>(type: "int", nullable: false),
                    Location_ValidFlag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Location_Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_Level = table.Column<int>(type: "int", nullable: false),
                    Member_ValidFlag = table.Column<int>(type: "int", nullable: false),
                    Member_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Member_Account = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Member_Password = table.Column<string>(type: "nvarchar(Max)", nullable: false),
                    Member_Address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Member_Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Member_Phone = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Member_CreateTime = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Member_img = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location_Id = table.Column<int>(type: "int", nullable: false),
                    Member_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Price = table.Column<int>(type: "int", nullable: false),
                    Order_Duration = table.Column<int>(type: "int", nullable: false),
                    Order_StartDateTime = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Order_EndDateTime = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Order_ValidFlag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Order_Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Products_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Products_Price = table.Column<int>(type: "int", nullable: false),
                    Products_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Products_DateTime = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Products_Inventory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Products_Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsOrder",
                columns: table => new
                {
                    ProductsOrder_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Products_Id = table.Column<int>(type: "int", nullable: false),
                    Member_Id = table.Column<int>(type: "int", nullable: false),
                    Member_Address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Member_Cellphone = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ProductsOrder_total = table.Column<int>(type: "int", nullable: false),
                    ProductsOrder_Count = table.Column<int>(type: "int", nullable: false),
                    ProductsOrder_DateTime = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOrder", x => x.ProductsOrder_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductsOrder");
        }
    }
}
