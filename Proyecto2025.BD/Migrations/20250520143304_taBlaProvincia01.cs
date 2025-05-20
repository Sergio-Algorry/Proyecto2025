using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class taBlaProvincia01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoEstados",
                table: "TipoEstados");

            migrationBuilder.RenameTable(
                name: "TipoEstados",
                newName: "TipoProvincias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoProvincias",
                table: "TipoProvincias",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisId = table.Column<int>(type: "int", nullable: false),
                    TipoProvinciaId = table.Column<int>(type: "int", nullable: false),
                    IGM_Id = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NombreProvincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provincias_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Provincias_TipoProvincias_TipoProvinciaId",
                        column: x => x.TipoProvinciaId,
                        principalTable: "TipoProvincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_PaisId",
                table: "Provincias",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_TipoProvinciaId",
                table: "Provincias",
                column: "TipoProvinciaId");

            migrationBuilder.CreateIndex(
                name: "Provincia_IGM_Id_UQ",
                table: "Provincias",
                column: "IGM_Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoProvincias",
                table: "TipoProvincias");

            migrationBuilder.RenameTable(
                name: "TipoProvincias",
                newName: "TipoEstados");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoEstados",
                table: "TipoEstados",
                column: "Id");
        }
    }
}
