using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class Paises01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alpha3Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodIndec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombrePais = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
