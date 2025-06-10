using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class ErrorIndice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provincias_Paises_PaisId",
                table: "Provincias");

            migrationBuilder.DropForeignKey(
                name: "FK_Provincias_TipoProvincias_TipoProvinciaId",
                table: "Provincias");

            migrationBuilder.CreateIndex(
                name: "TipoProvincia_UQ",
                table: "TipoProvincias",
                column: "Codigo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Provincias_Paises_PaisId",
                table: "Provincias",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Provincias_TipoProvincias_TipoProvinciaId",
                table: "Provincias",
                column: "TipoProvinciaId",
                principalTable: "TipoProvincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provincias_Paises_PaisId",
                table: "Provincias");

            migrationBuilder.DropForeignKey(
                name: "FK_Provincias_TipoProvincias_TipoProvinciaId",
                table: "Provincias");

            migrationBuilder.DropIndex(
                name: "TipoProvincia_UQ",
                table: "TipoProvincias");

            migrationBuilder.AddForeignKey(
                name: "FK_Provincias_Paises_PaisId",
                table: "Provincias",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provincias_TipoProvincias_TipoProvinciaId",
                table: "Provincias",
                column: "TipoProvinciaId",
                principalTable: "TipoProvincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
