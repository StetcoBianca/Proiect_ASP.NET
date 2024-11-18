using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClasaFitness",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeClasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacitate = table.Column<int>(type: "int", nullable: false),
                    ID_Instructor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasaFitness", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClasaFitness");
        }
    }
}
