using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorieFitness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriiFitness",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriiFitness", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClaseCategoriiFitness",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClasaFitnessID = table.Column<int>(type: "int", nullable: false),
                    CategorieFitnessID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseCategoriiFitness", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClaseCategoriiFitness_CategoriiFitness_CategorieFitnessID",
                        column: x => x.CategorieFitnessID,
                        principalTable: "CategoriiFitness",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaseCategoriiFitness_ClasaFitness_ClasaFitnessID",
                        column: x => x.ClasaFitnessID,
                        principalTable: "ClasaFitness",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaseCategoriiFitness_CategorieFitnessID",
                table: "ClaseCategoriiFitness",
                column: "CategorieFitnessID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaseCategoriiFitness_ClasaFitnessID",
                table: "ClaseCategoriiFitness",
                column: "ClasaFitnessID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaseCategoriiFitness");

            migrationBuilder.DropTable(
                name: "CategoriiFitness");
        }
    }
}
