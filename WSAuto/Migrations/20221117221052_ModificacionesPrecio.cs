using Microsoft.EntityFrameworkCore.Migrations;

namespace WSAuto.Migrations
{
    public partial class ModificacionesPrecio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Autores",
                type: "money",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Precio",
                table: "Autores",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
