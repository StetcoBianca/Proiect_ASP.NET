﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_ASP.NET.Data;

#nullable disable

namespace Proiect_ASP.NET.Migrations
{
    [DbContext(typeof(Proiect_ASPNETContext))]
    [Migration("20241118213413_SeedDataFix")]
    partial class SeedDataFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proiect_ASP.NET.Models.CategorieFitness", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("NumeCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CategoriiFitness");

                    b.HasData(
                        new
                        {
                            ID = 3,
                            NumeCategorie = "Cardio"
                        },
                        new
                        {
                            ID = 4,
                            NumeCategorie = "Stretching"
                        });
                });

            modelBuilder.Entity("Proiect_ASP.NET.Models.ClasaCategorieFitness", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategorieFitnessID")
                        .HasColumnType("int");

                    b.Property<int>("ClasaFitnessID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieFitnessID");

                    b.HasIndex("ClasaFitnessID");

                    b.ToTable("ClaseCategoriiFitness");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CategorieFitnessID = 3,
                            ClasaFitnessID = 1
                        },
                        new
                        {
                            ID = 2,
                            CategorieFitnessID = 4,
                            ClasaFitnessID = 2
                        });
                });

            modelBuilder.Entity("Proiect_ASP.NET.Models.ClasaFitness", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Capacitate")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InstructorID")
                        .HasColumnType("int");

                    b.Property<string>("NumeClasa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Orar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UtilizatorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InstructorID");

                    b.HasIndex("UtilizatorID");

                    b.ToTable("ClasaFitness");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Capacitate = 15,
                            Data = new DateTime(2024, 11, 19, 23, 34, 12, 822, DateTimeKind.Local).AddTicks(7366),
                            InstructorID = 1,
                            NumeClasa = "Zumba",
                            Orar = "Luni 18:00"
                        },
                        new
                        {
                            ID = 2,
                            Capacitate = 20,
                            Data = new DateTime(2024, 11, 20, 23, 34, 12, 822, DateTimeKind.Local).AddTicks(7423),
                            InstructorID = 2,
                            NumeClasa = "Pilates",
                            Orar = "Marti 19:00"
                        });
                });

            modelBuilder.Entity("Proiect_ASP.NET.Models.Instructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specializare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Instructor");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Nume = "Ana Popescu",
                            Specializare = "Aerobic"
                        },
                        new
                        {
                            ID = 2,
                            Nume = "Ion Ionescu",
                            Specializare = "Yoga"
                        });
                });

            modelBuilder.Entity("Proiect_ASP.NET.Models.Utilizator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipUtilizator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Utilizator");
                });

            modelBuilder.Entity("Proiect_ASP.NET.Models.ClasaCategorieFitness", b =>
                {
                    b.HasOne("Proiect_ASP.NET.Models.CategorieFitness", "CategorieFitness")
                        .WithMany("ClasaCategorieFitness")
                        .HasForeignKey("CategorieFitnessID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_ASP.NET.Models.ClasaFitness", "ClasaFitness")
                        .WithMany("ClasaCategorieFitness")
                        .HasForeignKey("ClasaFitnessID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategorieFitness");

                    b.Navigation("ClasaFitness");
                });

            modelBuilder.Entity("Proiect_ASP.NET.Models.ClasaFitness", b =>
                {
                    b.HasOne("Proiect_ASP.NET.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Proiect_ASP.NET.Models.Utilizator", "Utilizator")
                        .WithMany()
                        .HasForeignKey("UtilizatorID");

                    b.Navigation("Instructor");

                    b.Navigation("Utilizator");
                });

            modelBuilder.Entity("Proiect_ASP.NET.Models.CategorieFitness", b =>
                {
                    b.Navigation("ClasaCategorieFitness");
                });

            modelBuilder.Entity("Proiect_ASP.NET.Models.ClasaFitness", b =>
                {
                    b.Navigation("ClasaCategorieFitness");
                });
#pragma warning restore 612, 618
        }
    }
}