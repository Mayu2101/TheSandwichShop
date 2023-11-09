using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheSandwichShop.Migrations
{
    public partial class updatedERD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desserts");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Sandwiches");

            migrationBuilder.DropColumn(
                name: "DessertId",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "SandwichId",
                table: "Combos");

            migrationBuilder.RenameColumn(
                name: "OrderLineId",
                table: "Orders",
                newName: "EmployeeId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Toppings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "OrderLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Combos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SandwichBreadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SandwichToppingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComboId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Combos");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Orders",
                newName: "OrderLineId");

            migrationBuilder.AddColumn<Guid>(
                name: "DessertId",
                table: "Combos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DrinkId",
                table: "Combos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SandwichId",
                table: "Combos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Desserts",
                columns: table => new
                {
                    DessertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desserts", x => x.DessertId);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    DrinkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.DrinkId);
                });

            migrationBuilder.CreateTable(
                name: "Sandwiches",
                columns: table => new
                {
                    SandwichId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sandwiches", x => x.SandwichId);
                });
        }
    }
}
