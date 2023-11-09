using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheSandwichShop.Migrations
{
    public partial class updateBasePrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComboBasePrices",
                columns: table => new
                {
                    ComboBasePriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComboId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboBasePrices", x => x.ComboBasePriceId);
                });

            migrationBuilder.CreateTable(
                name: "ItemBasePrices",
                columns: table => new
                {
                    ItemBasePriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBasePrices", x => x.ItemBasePriceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboBasePrices");

            migrationBuilder.DropTable(
                name: "ItemBasePrices");
        }
    }
}
