﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using U_DO.Data;

#nullable disable

namespace U_DO.Migrations;

[DbContext(typeof(TaskContext))]
partial class TaskContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "7.0.9")
            .HasAnnotation("Relational:MaxIdentifierLength", 64);

        modelBuilder.Entity("U_DO.Models.ToDoTask", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<DateTime>("DueDate")
                    .HasColumnType("datetime(6)");

                b.Property<bool>("IsComplete")
                    .HasColumnType("tinyint(1)");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.HasKey("Id");

                b.ToTable("Tasks");
            });
#pragma warning restore 612, 618
    }
}
