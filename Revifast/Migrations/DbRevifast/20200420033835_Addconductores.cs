using Microsoft.EntityFrameworkCore.Migrations;

namespace Revifast.Migrations.DbRevifast
{
    public partial class Addconductores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Vehiculo");

            migrationBuilder.AddColumn<int>(
                name: "ConductorId",
                table: "Vehiculo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conductor",
                columns: table => new
                {
                    ConductorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(maxLength: 256, nullable: true),
                    Nombres = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Apellidos = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DNI = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Correo = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Celular = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductor", x => x.ConductorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_ConductorId",
                table: "Vehiculo",
                column: "ConductorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculo_Conductor",
                table: "Vehiculo",
                column: "ConductorId",
                principalTable: "Conductor",
                principalColumn: "ConductorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculo_Conductor",
                table: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Conductor");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculo_ConductorId",
                table: "Vehiculo");

            migrationBuilder.DropColumn(
                name: "ConductorId",
                table: "Vehiculo");

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Vehiculo",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
