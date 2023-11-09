using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheSandwichShop.Migrations
{
    public partial class updateItemFunctioning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComboId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemSizeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SandwichBreadId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SandwichToppingId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "ComboItems",
                columns: table => new
                {
                    ComboItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComboId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboItems", x => x.ComboItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboItems");

            migrationBuilder.AddColumn<Guid>(
                name: "ComboId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ItemSizeId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SandwichBreadId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SandwichToppingId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
