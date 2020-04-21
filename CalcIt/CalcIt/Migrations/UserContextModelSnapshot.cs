﻿// <auto-generated />
using System;
using CalcIt.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalcIt.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CalcIt.Models.CalculationModel", b =>
                {
                    b.Property<long>("calculation_id")
                        .HasColumnType("bigint");

                    b.Property<string>("calculation_data")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("calculation_date")
                        .HasColumnType("datetime2");

                    b.Property<long>("doctor_id")
                        .HasColumnType("bigint");

                    b.Property<long>("patient_id")
                        .HasColumnType("bigint");

                    b.Property<string>("result")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("calculation_id");

                    b.ToTable("Calculations");
                });

            modelBuilder.Entity("CalcIt.Models.DepartmentModel", b =>
                {
                    b.Property<long>("department_id")
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("department_id");

                    b.ToTable("Departmens");
                });

            modelBuilder.Entity("CalcIt.Models.DoctorModel", b =>
                {
                    b.Property<long>("doctor_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("login")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("speciality")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("doctor_id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("CalcIt.Models.PatientModel", b =>
                {
                    b.Property<long>("patient_id")
                        .HasColumnType("bigint");

                    b.Property<long>("PESEL")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("birthdate")
                        .HasColumnType("datetime2");

                    b.Property<long>("doctor_id")
                        .HasColumnType("bigint");

                    b.Property<double>("height")
                        .HasColumnType("float");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("registration_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<double>("weight")
                        .HasColumnType("float")
                        .HasMaxLength(50);

                    b.HasKey("patient_id");

                    b.ToTable("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
