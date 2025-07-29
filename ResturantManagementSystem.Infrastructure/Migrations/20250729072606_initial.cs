using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResturantManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreatedAt", "ItemType", "Name", "Price" },
                values: new object[,]
                {
                    { -13, new DateTime(2025, 7, 29, 10, 26, 5, 876, DateTimeKind.Local).AddTicks(1896), "Food", "Pizza", 12.00m },
                    { -12, new DateTime(2025, 7, 29, 10, 26, 5, 876, DateTimeKind.Local).AddTicks(1893), "Food", "Salad", 7.50m },
                    { -11, new DateTime(2025, 7, 29, 10, 26, 5, 876, DateTimeKind.Local).AddTicks(1872), "Food", "Burger", 10.99m }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreatedAt", "ItemType", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { -3, new DateTime(2025, 7, 29, 10, 26, 5, 875, DateTimeKind.Local).AddTicks(6841), "Drink", "Iced Tea", 3.75m, "Cold" },
                    { -2, new DateTime(2025, 7, 29, 10, 26, 5, 875, DateTimeKind.Local).AddTicks(6803), "Drink", "Hot Chocolate", 5.00m, "Hot" },
                    { -1, new DateTime(2025, 7, 29, 10, 26, 5, 874, DateTimeKind.Local).AddTicks(1115), "Drink", "Coffee", 4.50m, "Hot" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
