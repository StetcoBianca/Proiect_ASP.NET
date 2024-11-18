using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proiect_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriiFitness",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoriiFitness",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "CategoriiFitness",
                columns: new[] { "ID", "NumeCategorie" },
                values: new object[,]
                {
                    { 3, "Cardio" },
                    { 4, "Stretching" }
                });

            migrationBuilder.UpdateData(
                table: "ClasaFitness",
                keyColumn: "ID",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2024, 11, 19, 23, 34, 12, 822, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "ClasaFitness",
                keyColumn: "ID",
                keyValue: 2,
                column: "Data",
                value: new DateTime(2024, 11, 20, 23, 34, 12, 822, DateTimeKind.Local).AddTicks(7423));

            migrationBuilder.UpdateData(
                table: "ClaseCategoriiFitness",
                keyColumn: "ID",
                keyValue: 1,
                column: "CategorieFitnessID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ClaseCategoriiFitness",
                keyColumn: "ID",
                keyValue: 2,
                column: "CategorieFitnessID",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoriiFitness",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoriiFitness",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "CategoriiFitness",
                columns: new[] { "ID", "NumeCategorie" },
                values: new object[,]
                {
                    { 1, "Cardio" },
                    { 2, "Stretching" }
                });

            migrationBuilder.UpdateData(
                table: "ClasaFitness",
                keyColumn: "ID",
                keyValue: 1,
                column: "Data",
                value: new DateTime(2024, 11, 19, 23, 28, 59, 200, DateTimeKind.Local).AddTicks(6669));

            migrationBuilder.UpdateData(
                table: "ClasaFitness",
                keyColumn: "ID",
                keyValue: 2,
                column: "Data",
                value: new DateTime(2024, 11, 20, 23, 28, 59, 200, DateTimeKind.Local).AddTicks(6723));

            migrationBuilder.UpdateData(
                table: "ClaseCategoriiFitness",
                keyColumn: "ID",
                keyValue: 1,
                column: "CategorieFitnessID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ClaseCategoriiFitness",
                keyColumn: "ID",
                keyValue: 2,
                column: "CategorieFitnessID",
                value: 2);
        }
    }
}
