﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using c;

#nullable disable

namespace HW4_StudentDBManipulations.Migrations
{
    [DbContext(typeof(StudentDB))]
    [Migration("20240216050042_createstudb")]
    partial class createstudb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("c.Student", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<double>("Grade")
                        .HasColumnType("REAL");

                    b.Property<int>("GradeLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}