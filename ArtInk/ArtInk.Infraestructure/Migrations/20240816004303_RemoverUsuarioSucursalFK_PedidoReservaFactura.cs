using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoverUsuarioSucursalFK_PedidoReservaFactura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_UsuarioSucursal",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_UsuarioSucursal",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_UsuarioSucursal",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IdUsuarioSucursal",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdUsuarioSucursal",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Factura_IdUsuarioSucursal",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "IdUsuarioSucursal",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdUsuarioSucursal",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdUsuarioSucursal",
                table: "Factura");

            migrationBuilder.AddColumn<byte>(
                name: "IdSucursal",
                table: "Pedido",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "IdSucursal",
                table: "Factura",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdSucursal",
                table: "Pedido",
                column: "IdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdSucursal",
                table: "Factura",
                column: "IdSucursal");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Sucursal",
                table: "Factura",
                column: "IdSucursal",
                principalTable: "Sucursal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Sucursal",
                table: "Pedido",
                column: "IdSucursal",
                principalTable: "Sucursal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Sucursal",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Sucursal",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdSucursal",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Factura_IdSucursal",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "IdSucursal",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdSucursal",
                table: "Factura");

            migrationBuilder.AddColumn<short>(
                name: "IdUsuarioSucursal",
                table: "Reserva",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "IdUsuarioSucursal",
                table: "Pedido",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "IdUsuarioSucursal",
                table: "Factura",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdUsuarioSucursal",
                table: "Reserva",
                column: "IdUsuarioSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdUsuarioSucursal",
                table: "Pedido",
                column: "IdUsuarioSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdUsuarioSucursal",
                table: "Factura",
                column: "IdUsuarioSucursal");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_UsuarioSucursal",
                table: "Factura",
                column: "IdUsuarioSucursal",
                principalTable: "UsuarioSucursal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_UsuarioSucursal",
                table: "Pedido",
                column: "IdUsuarioSucursal",
                principalTable: "UsuarioSucursal",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_UsuarioSucursal",
                table: "Reserva",
                column: "IdUsuarioSucursal",
                principalTable: "UsuarioSucursal",
                principalColumn: "Id");
        }
    }
}
