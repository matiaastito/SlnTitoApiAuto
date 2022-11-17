using Microsoft.EntityFrameworkCore.Migrations;

namespace WSAuto.Migrations
{
    public partial class CambioNombreTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Autores",
                table: "Autores");

            migrationBuilder.RenameTable(
                name: "Autores",
                newName: "Vehiculo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehiculo",
                table: "Vehiculo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehiculo",
                table: "Vehiculo");

            migrationBuilder.RenameTable(
                name: "Vehiculo",
                newName: "Autores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autores",
                table: "Autores",
                column: "Id");
        }
    }
}
