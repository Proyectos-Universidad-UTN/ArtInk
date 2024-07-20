using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Pedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PedidoId",
                table: "DetalleFactura",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<short>(type: "smallint", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    IdTipoPago = table.Column<byte>(type: "tinyint", nullable: false),
                    Consecutivo = table.Column<short>(type: "smallint", nullable: false),
                    IdUsuarioSucursal = table.Column<short>(type: "smallint", nullable: false),
                    IdImpuesto = table.Column<byte>(type: "tinyint", nullable: false),
                    PorcentajeImpuesto = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false),
                    MontoImpuesto = table.Column<decimal>(type: "money", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "money", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedido_Impuesto",
                        column: x => x.IdImpuesto,
                        principalTable: "Impuesto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedido_TipoPago",
                        column: x => x.IdTipoPago,
                        principalTable: "TipoPago",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedido_UsuarioSucursal",
                        column: x => x.IdUsuarioSucursal,
                        principalTable: "UsuarioSucursal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_PedidoId",
                table: "DetalleFactura",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdImpuesto",
                table: "Pedido",
                column: "IdImpuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdTipoPago",
                table: "Pedido",
                column: "IdTipoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdUsuarioSucursal",
                table: "Pedido",
                column: "IdUsuarioSucursal");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFactura_Pedido_PedidoId",
                table: "DetalleFactura",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFactura_Pedido_PedidoId",
                table: "DetalleFactura");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_DetalleFactura_PedidoId",
                table: "DetalleFactura");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "DetalleFactura");
        }
    }
}
