using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class AddUtilizatorToClaseFitness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UtilizatorID",
                table: "ClasaFitness",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipUtilizator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizator", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClasaFitness_UtilizatorID",
                table: "ClasaFitness",
                column: "UtilizatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClasaFitness_Utilizator_UtilizatorID",
                table: "ClasaFitness",
                column: "UtilizatorID",
                principalTable: "Utilizator",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClasaFitness_Utilizator_UtilizatorID",
                table: "ClasaFitness");

            migrationBuilder.DropTable(
                name: "Utilizator");

            migrationBuilder.DropIndex(
                name: "IX_ClasaFitness_UtilizatorID",
                table: "ClasaFitness");

            migrationBuilder.DropColumn(
                name: "UtilizatorID",
                table: "ClasaFitness");
        }
    }
}
