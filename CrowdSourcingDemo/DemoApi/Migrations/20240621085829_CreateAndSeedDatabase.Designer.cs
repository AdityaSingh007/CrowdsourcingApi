﻿// <auto-generated />
using DemoApi.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240621085829_CreateAndSeedDatabase")]
    partial class CreateAndSeedDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("DemoApi.EfCore.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeId");

                    b.ToTable("employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Department = "I&T",
                            Name = "Test"
                        },
                        new
                        {
                            EmployeeId = 2,
                            Department = "I&A",
                            Name = "Test1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
