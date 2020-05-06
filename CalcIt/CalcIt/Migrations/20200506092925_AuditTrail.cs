using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalcIt.Migrations
{
    public partial class AuditTrail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "calculation_type",
                table: "Calculations",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuditTrails",
                columns: table => new
                {
                    at_id = table.Column<long>(nullable: false),
                    doctor_id = table.Column<long>(nullable: false),
                    date_time = table.Column<DateTime>(nullable: false),
                    events = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrails", x => x.at_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditTrails");

            migrationBuilder.DropColumn(
                name: "calculation_type",
                table: "Calculations");
        }
    }
}
