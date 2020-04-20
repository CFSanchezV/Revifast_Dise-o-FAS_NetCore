using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Revifast.Migrations.DbRevifast
{
    public partial class addedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Reserva",
                newName: "fecha_y_hora");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_y_hora",
                table: "Reserva",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fecha_y_hora",
                table: "Reserva",
                newName: "Fecha");

            migrationBuilder.AlterColumn<string>(
                name: "Fecha",
                table: "Reserva",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
