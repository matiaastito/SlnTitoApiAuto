using Microsoft.EntityFrameworkCore.Migrations;

namespace WSAuto.Migrations
{
    public partial class CrearBaseDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(maxLength: 30, nullable: false),
                    Modelo = table.Column<string>(maxLength: 30, nullable: false),
                    Color = table.Column<string>(maxLength: 15, nullable: false),
                    Precio = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
