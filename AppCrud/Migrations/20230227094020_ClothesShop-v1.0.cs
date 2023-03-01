using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClothesShopv10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeClothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeClothes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentalTime = table.Column<int>(type: "int", nullable: false),
                    RentalPrice = table.Column<int>(type: "int", nullable: false),
                    TypeClothesId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clothes_TypeClothes_TypeClothesId",
                        column: x => x.TypeClothesId,
                        principalTable: "TypeClothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

          
            migrationBuilder.InsertData(
                table: "TypeClothes",
                columns: new[] { "Id", "Limit", "Name" },
                values: new object[,]
                {
                    { 1, 15, "Váy" },
                    { 2, 20, "Áo" }
                });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "Description", "Name", "Price", "RentalPrice", "RentalTime", "Size", "Status", "TypeClothesId" },
                values: new object[,]
                {
                    { 1, "Màu trắng", "Váy công sở Zara", 89.99m, 200000, 0, 2, 0, 1 },
                    { 2, "Màu đen", "Áo công sở Uniqlo", 58.99m, 100000, 0, 1, 0, 2 }
                });


            migrationBuilder.CreateIndex(
                name: "IX_Clothes_TypeClothesId",
                table: "Clothes",
                column: "TypeClothesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "TypeClothes");

        }
    }
}
