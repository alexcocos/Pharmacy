using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Migrations
{
    public partial class NumeroCinco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieID",
                table: "Medicament",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicament_CategorieID",
                table: "Medicament",
                column: "CategorieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicament_Categorie_CategorieID",
                table: "Medicament",
                column: "CategorieID",
                principalTable: "Categorie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicament_Categorie_CategorieID",
                table: "Medicament");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Medicament_CategorieID",
                table: "Medicament");

            migrationBuilder.DropColumn(
                name: "CategorieID",
                table: "Medicament");
        }
    }
}
