using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsCenter.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Products_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Products_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Products_Price = table.Column<int>(type: "int", nullable: false),
                    Products_DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Products_Inventory = table.Column<int>(type: "int", nullable: false),
                    Products_ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Products_Id);
                    table.ForeignKey(
                        name: "FK_Products_Item_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationBranch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location_Id = table.Column<int>(type: "int", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationBranch_Category_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationBranch_Location_Location_Id",
                        column: x => x.Location_Id,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location_Id = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationImage_Location_Location_Id",
                        column: x => x.Location_Id,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_Id = table.Column<int>(type: "int", nullable: false),
                    Member_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Member_Cellphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsOrder_Member_Member_Id",
                        column: x => x.Member_Id,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_Id = table.Column<int>(type: "int", nullable: false),
                    Products_Id = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsCart_Member_Member_Id",
                        column: x => x.Member_Id,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsCart_Products_Products_Id",
                        column: x => x.Products_Id,
                        principalTable: "Products",
                        principalColumn: "Products_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationBranch_Id = table.Column<int>(type: "int", nullable: false),
                    Member_Id = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocationBranchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationOrder_Location_LocationBranch_Id",
                        column: x => x.LocationBranch_Id,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationOrder_LocationBranch_LocationBranchId",
                        column: x => x.LocationBranchId,
                        principalTable: "LocationBranch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LocationOrder_Member_Member_Id",
                        column: x => x.Member_Id,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Products_Price = table.Column<int>(type: "int", nullable: false),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsOrderDetail_ProductsOrder_ProductOrderId",
                        column: x => x.ProductOrderId,
                        principalTable: "ProductsOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationBranch_Category_Id",
                table: "LocationBranch",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LocationBranch_Location_Id",
                table: "LocationBranch",
                column: "Location_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_Location_Id",
                table: "LocationImage",
                column: "Location_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LocationOrder_LocationBranch_Id",
                table: "LocationOrder",
                column: "LocationBranch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LocationOrder_LocationBranchId",
                table: "LocationOrder",
                column: "LocationBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationOrder_Member_Id",
                table: "LocationOrder",
                column: "Member_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Item_Id",
                table: "Products",
                column: "Item_Id");

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
                name: "IX_ProductsOrderDetail_ProductOrderId",
                table: "ProductsOrderDetail",
                column: "ProductOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationImage");

            migrationBuilder.DropTable(
                name: "LocationOrder");

            migrationBuilder.DropTable(
                name: "ProductsCart");

            migrationBuilder.DropTable(
                name: "ProductsOrderDetail");

            migrationBuilder.DropTable(
                name: "LocationBranch");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductsOrder");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
