﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleMinimalApi.EfCore;

#nullable disable

namespace SampleMinimalApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("SampleMinimalApi.EfCore.Entity.Employee", b =>
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
