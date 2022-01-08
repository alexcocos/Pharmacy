using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Migrations
{
    public partial class NumeroQuattro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FabricantID",
                table: "Medicament",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Fabricant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricant", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicament_FabricantID",
                table: "Medicament",
                column: "FabricantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicament_Fabricant_FabricantID",
                table: "Medicament",
                column: "FabricantID",
                principalTable: "Fabricant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicament_Fabricant_FabricantID",
                table: "Medicament");

            migrationBuilder.DropTable(
                name: "Fabricant");

            migrationBuilder.DropIndex(
                name: "IX_Medicament_FabricantID",
                table: "Medicament");

            migrationBuilder.DropColumn(
                name: "FabricantID",
                table: "Medicament");
        }
    }
}
