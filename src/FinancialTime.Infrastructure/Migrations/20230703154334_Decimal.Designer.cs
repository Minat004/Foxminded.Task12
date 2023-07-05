﻿// <auto-generated />
using System;
using FinancialTime.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinancialTime.Infrastructure.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    [Migration("20230703154334_Decimal")]
    partial class Decimal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinancialTime.Core.Models.FinOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FinTypeId");

                    b.ToTable("FinOperations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FinTypeId = 1,
                            Value = 4000m
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FinTypeId = 2,
                            Value = 1000m
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FinTypeId = 3,
                            Value = 133m
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FinTypeId = 4,
                            Value = 100m
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FinTypeId = 4,
                            Value = 150m
                        });
                });

            modelBuilder.Entity("FinancialTime.Core.Models.FinType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("FinTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Budget = 0,
                            Name = "Salary"
                        },
                        new
                        {
                            Id = 2,
                            Budget = 1,
                            Name = "Products"
                        },
                        new
                        {
                            Id = 3,
                            Budget = 1,
                            Name = "Fun"
                        },
                        new
                        {
                            Id = 4,
                            Budget = 1,
                            Name = "Restaurants"
                        });
                });

            modelBuilder.Entity("FinancialTime.Core.Models.FinOperation", b =>
                {
                    b.HasOne("FinancialTime.Core.Models.FinType", "FinType")
                        .WithMany("ListOperations")
                        .HasForeignKey("FinTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinType");
                });

            modelBuilder.Entity("FinancialTime.Core.Models.FinType", b =>
                {
                    b.Navigation("ListOperations");
                });
#pragma warning restore 612, 618
        }
    }
}