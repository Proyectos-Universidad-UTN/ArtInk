using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Reserva_AgregarUsuarioSucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "IdUsuarioSucursal",
                table: "Reserva",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdUsuarioSucursal",
                table: "Reserva",
                column: "IdUsuarioSucursal");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_UsuarioSucursal",
                table: "Reserva",
                column: "IdUsuarioSucursal",
                principalTable: "UsuarioSucursal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_UsuarioSucursal",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IdUsuarioSucursal",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdUsuarioSucursal",
                table: "Reserva");
        }
    }
}
