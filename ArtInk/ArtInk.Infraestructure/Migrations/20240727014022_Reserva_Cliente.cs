using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Reserva_Cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "IdCliente",
                table: "Reserva",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<string>(
                name: "NombreCliente",
                table: "Reserva",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdCliente",
                table: "Reserva",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente",
                table: "Reserva",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IdCliente",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "NombreCliente",
                table: "Reserva");
        }
    }
}
