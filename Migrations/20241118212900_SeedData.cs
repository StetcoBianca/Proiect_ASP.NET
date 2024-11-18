using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proiect_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CategoriiFitness",
                columns: new[] { "ID", "NumeCategorie" },
                values: new object[,]
                {
                    { 1, "Cardio" },
                    { 2, "Stretching" }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "ID", "Nume", "Specializare" },
                values: new object[,]
                {
                    { 1, "Ana Popescu", "Aerobic" },
                    { 2, "Ion Ionescu", "Yoga" }
                });

            migrationBuilder.InsertData(
                table: "ClasaFitness",
                columns: new[] { "ID", "Capacitate", "Data", "InstructorID", "NumeClasa", "Orar", "UtilizatorID" },
                values: new object[,]
                {
                    { 1, 15, new DateTime(2024, 11, 19, 23, 28, 59, 200, DateTimeKind.Local).AddTicks(6669), 1, "Zumba", "Luni 18:00", null },
                    { 2, 20, new DateTime(2024, 11, 20, 23, 28, 59, 200, DateTimeKind.Local).AddTicks(6723), 2, "Pilates", "Marti 19:00", null }
                });

            migrationBuilder.InsertData(
                table: "ClaseCategoriiFitness",
                columns: new[] { "ID", "CategorieFitnessID", "ClasaFitnessID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClaseCategoriiFitness",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClaseCategoriiFitness",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoriiFitness",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoriiFitness",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClasaFitness",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClasaFitness",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
