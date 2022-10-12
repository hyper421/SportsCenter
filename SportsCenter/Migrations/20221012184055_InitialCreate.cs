using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsCenter.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Location_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Location_Area = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Location_Address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Location_Phone = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Location_Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
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
                    Member_ValidFlag = table.Column<int>(type: "int", nullable: false),
                    Member_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Member_Account = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Member_Password = table.Column<string>(type: "nvarchar(Max)", nullable: false),
                    Member_Address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Member_Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Member_Phone = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Member_CreateTime = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Member_img = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Member_Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Products_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Products_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Products_Price = table.Column<int>(type: "int", nullable: false),
                    Products_DateTime = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Products_Inventory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Products_Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationBranch",
                columns: table => new
                {
                    LocationBranch_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location_Id = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    LocationBranch_partition = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LocationBranch_Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationBranch", x => x.LocationBranch_Id);
                    table.ForeignKey(
                        name: "FK_LocationBranch_Item_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Item",
                        principalColumn: "Item_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationBranch_Location_Location_Id",
                        column: x => x.Location_Id,
                        principalTable: "Location",
                        principalColumn: "Location_Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_Chat_Member_Member_Id",
                        column: x => x.Member_Id,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location_Id = table.Column<int>(type: "int", nullable: false),
                    Member_Id = table.Column<int>(type: "int", nullable: false),
                    LocationOrder_Price = table.Column<int>(type: "int", nullable: false),
                    LocationOrder_StartDateTime = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LocationOrder_EndDateTime = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Order_Id);
                    table.ForeignKey(
                        name: "FK_Order_Location_Location_Id",
                        column: x => x.Location_Id,
                        principalTable: "Location",
                        principalColumn: "Location_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Member_Member_Id",
                        column: x => x.Member_Id,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsCart",
                columns: table => new
                {
                    ProductsCart_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_Id = table.Column<int>(type: "int", nullable: false),
                    Products_Id = table.Column<int>(type: "int", nullable: false),
                    Products_Name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Products_Price = table.Column<int>(type: "int", nullable: false),
                    ProductsCart_Count = table.Column<int>(type: "int", nullable: false),
                    ProductsCart_Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsCart", x => x.ProductsCart_ID);
                    table.ForeignKey(
                        name: "FK_ProductsCart_Member_Member_Id",
                        column: x => x.Member_Id,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsCart_Products_Products_Id",
                        column: x => x.Products_Id,
                        principalTable: "Products",
                        principalColumn: "Products_Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ProductsOrder_Count = table.Column<int>(type: "int", nullable: false),
                    ProductsOrder_Total = table.Column<int>(type: "int", nullable: false),
                    ProductsOrder_DateTime = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOrder", x => x.ProductsOrder_Id);
                    table.ForeignKey(
                        name: "FK_ProductsOrder_Member_Member_Id",
                        column: x => x.Member_Id,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsOrder_Products_Products_Id",
                        column: x => x.Products_Id,
                        principalTable: "Products",
                        principalColumn: "Products_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_Member_Id",
                table: "Chat",
                column: "Member_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LocationBranch_Item_Id",
                table: "LocationBranch",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LocationBranch_Location_Id",
                table: "LocationBranch",
                column: "Location_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Location_Id",
                table: "Order",
                column: "Location_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Member_Id",
                table: "Order",
                column: "Member_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCart_Member_Id",
                table: "ProductsCart",
                column: "Member_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCart_Products_Id",
                table: "ProductsCart",
                column: "Products_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOrder_Member_Id",
                table: "ProductsOrder",
                column: "Member_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOrder_Products_Id",
                table: "ProductsOrder",
                column: "Products_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "LocationBranch");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProductsCart");

            migrationBuilder.DropTable(
                name: "ProductsOrder");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
