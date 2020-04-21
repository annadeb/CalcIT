using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalcIt.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    calculation_id = table.Column<long>(nullable: false),
                    patient_id = table.Column<long>(nullable: false),
                    doctor_id = table.Column<long>(nullable: false),
                    calculation_date = table.Column<DateTime>(nullable: false),
                    calculation_data = table.Column<string>(maxLength: 255, nullable: true),
                    result = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.calculation_id);
                });

            migrationBuilder.CreateTable(
                name: "Departmens",
                columns: table => new
                {
                    department_id = table.Column<long>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmens", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    doctor_id = table.Column<long>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    surname = table.Column<string>(maxLength: 50, nullable: true),
                    speciality = table.Column<string>(maxLength: 50, nullable: true),
                    birthdate = table.Column<DateTime>(nullable: false),
                    login = table.Column<string>(maxLength: 50, nullable: true),
                    password = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.doctor_id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    patient_id = table.Column<long>(nullable: false),
                    doctor_id = table.Column<long>(nullable: false),
                    PESEL = table.Column<long>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    surname = table.Column<string>(maxLength: 50, nullable: true),
                    weight = table.Column<double>(maxLength: 50, nullable: false),
                    height = table.Column<double>(nullable: false),
                    registration_date = table.Column<DateTime>(nullable: false),
                    birthdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.patient_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");

            migrationBuilder.DropTable(
                name: "Departmens");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
