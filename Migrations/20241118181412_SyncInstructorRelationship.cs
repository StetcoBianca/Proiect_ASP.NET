using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class SyncInstructorRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_Instructor",
                table: "ClasaFitness");

            migrationBuilder.AddColumn<int>(
                name: "InstructorID",
                table: "ClasaFitness",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specializare = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClasaFitness_InstructorID",
                table: "ClasaFitness",
                column: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClasaFitness_Instructor_InstructorID",
                table: "ClasaFitness",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull); // Relație SetNull
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClasaFitness_Instructor_InstructorID",
                table: "ClasaFitness");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_ClasaFitness_InstructorID",
                table: "ClasaFitness");

            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "ClasaFitness");

            migrationBuilder.AddColumn<int>(
                name: "ID_Instructor",
                table: "ClasaFitness",
                type: "int",
                nullable: true); // Corectăm comportamentul nullable
        }
    }
}
