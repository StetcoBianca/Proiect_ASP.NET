using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToClasaFitness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "ClasaFitness",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "ClasaFitness");
        }
    }
}
