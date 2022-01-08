using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy.Migrations
{
    public partial class NumeroTres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Medicament",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddColumn<int>(
                name: "AdministrareID",
                table: "Medicament",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Administrare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrare", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicament_AdministrareID",
                table: "Medicament",
                column: "AdministrareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicament_Administrare_AdministrareID",
                table: "Medicament",
                column: "AdministrareID",
                principalTable: "Administrare",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicament_Administrare_AdministrareID",
                table: "Medicament");

            migrationBuilder.DropTable(
                name: "Administrare");

            migrationBuilder.DropIndex(
                name: "IX_Medicament_AdministrareID",
                table: "Medicament");

            migrationBuilder.DropColumn(
                name: "AdministrareID",
                table: "Medicament");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Medicament",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
