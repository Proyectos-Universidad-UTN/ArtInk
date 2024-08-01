using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Pedido_Reserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdReserva",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdReserva",
                table: "Pedido",
                column: "IdReserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Reserva",
                table: "Pedido",
                column: "IdReserva",
                principalTable: "Reserva",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Reserva",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdReserva",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdReserva",
                table: "Pedido");
        }
    }
}
