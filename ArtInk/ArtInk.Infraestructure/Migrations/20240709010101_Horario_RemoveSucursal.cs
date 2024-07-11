using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Horario_RemoveSucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horario_Sucursal",
                table: "Horario");

            migrationBuilder.DropIndex(
                name: "IX_Horario_IdSucursal",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "IdSucursal",
                table: "Horario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "IdSucursal",
                table: "Horario",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_Horario_IdSucursal",
                table: "Horario",
                column: "IdSucursal");

            migrationBuilder.AddForeignKey(
                name: "FK_Horario_Sucursal",
                table: "Horario",
                column: "IdSucursal",
                principalTable: "Sucursal",
                principalColumn: "Id");
        }
    }
}
