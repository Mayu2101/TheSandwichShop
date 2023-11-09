using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheSandwichShop.Migrations
{
    public partial class shiftUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeShifts",
                columns: table => new
                {
                    EmployeeShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShifts", x => x.EmployeeShiftId);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfEmpBooked = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeShifts");

            migrationBuilder.DropTable(
                name: "Shifts");
        }
    }
}
