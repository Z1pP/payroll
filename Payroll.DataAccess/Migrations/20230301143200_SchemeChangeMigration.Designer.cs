﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payroll.DataAccess.DataBase;

#nullable disable

namespace Payroll.DataAccess.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230301143200_SchemeChangeMigration")]
    partial class SchemeChangeMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Payroll.DataAccess.Models.Employees.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalHoursWorked")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Employee");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Payroll.DataAccess.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("WorkingTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("Payroll.DataAccess.Models.Employees.Freelancer", b =>
                {
                    b.HasBaseType("Payroll.DataAccess.Models.Employees.Employee");

                    b.HasDiscriminator().HasValue("Freelancer");
                });

            modelBuilder.Entity("Payroll.DataAccess.Models.Employees.Manager", b =>
                {
                    b.HasBaseType("Payroll.DataAccess.Models.Employees.Employee");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("Payroll.DataAccess.Models.Employees.Worker", b =>
                {
                    b.HasBaseType("Payroll.DataAccess.Models.Employees.Employee");

                    b.HasDiscriminator().HasValue("Worker");
                });

            modelBuilder.Entity("Payroll.DataAccess.Models.Mission", b =>
                {
                    b.HasOne("Payroll.DataAccess.Models.Employees.Employee", "Employee")
                        .WithMany("Missions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Payroll.DataAccess.Models.Employees.Employee", b =>
                {
                    b.Navigation("Missions");
                });
#pragma warning restore 612, 618
        }
    }
}