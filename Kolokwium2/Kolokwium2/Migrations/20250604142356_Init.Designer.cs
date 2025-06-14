﻿// <auto-generated />
using System;
using Kolokwium2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kolokwium2.Migrations
{
    [DbContext(typeof(ApbdContext))]
    [Migration("20250604142356_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kolokwium2.Models.Available_Program", b =>
                {
                    b.Property<int>("AvailableProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvailableProgramId"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.Property<int>("WashingMachineId")
                        .HasColumnType("int");

                    b.HasKey("AvailableProgramId");

                    b.HasIndex("ProgramId");

                    b.HasIndex("WashingMachineId");

                    b.ToTable("Available_Program");

                    b.HasData(
                        new
                        {
                            AvailableProgramId = 1,
                            Price = 9.99m,
                            ProgramId = 1,
                            WashingMachineId = 1
                        },
                        new
                        {
                            AvailableProgramId = 2,
                            Price = 15.99m,
                            ProgramId = 2,
                            WashingMachineId = 1
                        },
                        new
                        {
                            AvailableProgramId = 3,
                            Price = 68.99m,
                            ProgramId = 3,
                            WashingMachineId = 2
                        },
                        new
                        {
                            AvailableProgramId = 4,
                            Price = 19.99m,
                            ProgramId = 2,
                            WashingMachineId = 3
                        },
                        new
                        {
                            AvailableProgramId = 5,
                            Price = 95.99m,
                            ProgramId = 3,
                            WashingMachineId = 3
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            CustomerId = 2,
                            FirstName = "Jane",
                            LastName = "Doe"
                        },
                        new
                        {
                            CustomerId = 3,
                            FirstName = "Julie",
                            LastName = "Doe"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.ProgramEntity", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgramId"));

                    b.Property<int>("DurationMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TemperatureCelsius")
                        .HasColumnType("int");

                    b.HasKey("ProgramId");

                    b.ToTable("Program");

                    b.HasData(
                        new
                        {
                            ProgramId = 1,
                            DurationMinutes = 50,
                            Name = "Program 1",
                            TemperatureCelsius = 90
                        },
                        new
                        {
                            ProgramId = 2,
                            DurationMinutes = 60,
                            Name = "Program 2",
                            TemperatureCelsius = 60
                        },
                        new
                        {
                            ProgramId = 3,
                            DurationMinutes = 15,
                            Name = "Program 3",
                            TemperatureCelsius = 30
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Purchase_History", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("AvailableProgramId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("CustomerId", "AvailableProgramId");

                    b.HasIndex("AvailableProgramId");

                    b.ToTable("Purchase_History");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            AvailableProgramId = 1,
                            PurchaseDate = new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 3
                        },
                        new
                        {
                            CustomerId = 1,
                            AvailableProgramId = 2,
                            PurchaseDate = new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 3
                        },
                        new
                        {
                            CustomerId = 2,
                            AvailableProgramId = 3,
                            PurchaseDate = new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 3,
                            AvailableProgramId = 4,
                            PurchaseDate = new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CustomerId = 2,
                            AvailableProgramId = 5,
                            PurchaseDate = new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Washing_Machine", b =>
                {
                    b.Property<int>("WashingMachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WashingMachineId"));

                    b.Property<decimal>("MaxWeight")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("WashingMachineId");

                    b.ToTable("Washing_Machine");

                    b.HasData(
                        new
                        {
                            WashingMachineId = 1,
                            MaxWeight = 96.5m,
                            SerialNumber = "Serial number 1"
                        },
                        new
                        {
                            WashingMachineId = 2,
                            MaxWeight = 106m,
                            SerialNumber = "Serial number 2"
                        },
                        new
                        {
                            WashingMachineId = 3,
                            MaxWeight = 57.4m,
                            SerialNumber = "Serial number 3"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Available_Program", b =>
                {
                    b.HasOne("Kolokwium2.Models.ProgramEntity", "ProgramEntity")
                        .WithMany("AvailablePrograms")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models.Washing_Machine", "WashingMachine")
                        .WithMany("AvailablePrograms")
                        .HasForeignKey("WashingMachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramEntity");

                    b.Navigation("WashingMachine");
                });

            modelBuilder.Entity("Kolokwium2.Models.Purchase_History", b =>
                {
                    b.HasOne("Kolokwium2.Models.Available_Program", "AvailableProgram")
                        .WithMany("PurchaseHistory")
                        .HasForeignKey("AvailableProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models.Customer", "Customer")
                        .WithMany("PurchaseHistory")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AvailableProgram");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Kolokwium2.Models.Available_Program", b =>
                {
                    b.Navigation("PurchaseHistory");
                });

            modelBuilder.Entity("Kolokwium2.Models.Customer", b =>
                {
                    b.Navigation("PurchaseHistory");
                });

            modelBuilder.Entity("Kolokwium2.Models.ProgramEntity", b =>
                {
                    b.Navigation("AvailablePrograms");
                });

            modelBuilder.Entity("Kolokwium2.Models.Washing_Machine", b =>
                {
                    b.Navigation("AvailablePrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
