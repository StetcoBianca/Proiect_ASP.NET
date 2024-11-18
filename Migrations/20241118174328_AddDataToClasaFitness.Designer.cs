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
    [Migration("20241118174328_AddDataToClasaFitness")]
    partial class AddDataToClasaFitness
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<int>("ID_Instructor")
                        .HasColumnType("int");

                    b.Property<string>("NumeClasa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Orar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ClasaFitness");
                });
#pragma warning restore 612, 618
        }
    }
}
