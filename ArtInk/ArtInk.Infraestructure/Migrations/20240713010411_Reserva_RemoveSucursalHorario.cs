using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Reserva_RemoveSucursalHorario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_SucursalHorario",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IdSucursalHorario",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdSucursalHorario",
                table: "Reserva");

            migrationBuilder.AddColumn<byte>(
                name: "IdSucursal",
                table: "Reserva",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdSucursal",
                table: "Reserva",
                column: "IdSucursal");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Sucursal",
                table: "Reserva",
                column: "IdSucursal",
                principalTable: "Sucursal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Sucursal",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IdSucursal",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdSucursal",
                table: "Reserva");

            migrationBuilder.AddColumn<short>(
                name: "IdSucursalHorario",
                table: "Reserva",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdSucursalHorario",
                table: "Reserva",
                column: "IdSucursalHorario");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_SucursalHorario",
                table: "Reserva",
                column: "IdSucursalHorario",
                principalTable: "SucursalHorario",
                principalColumn: "Id");
        }
    }
}
