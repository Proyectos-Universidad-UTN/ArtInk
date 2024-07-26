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
                name: "IdPedido",
                table: "Factura",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPedido = table.Column<long>(type: "bigint", nullable: false),
                    IdServicio = table.Column<byte>(type: "tinyint", nullable: false),
                    NumeroLinea = table.Column<byte>(type: "tinyint", nullable: false),
                    Cantidad = table.Column<short>(type: "smallint", nullable: false),
                    TarifaServicio = table.Column<decimal>(type: "money", nullable: false),
                    MontoSubtotal = table.Column<decimal>(type: "money", nullable: false),
                    MontoImpuesto = table.Column<decimal>(type: "money", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallePedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Pedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetallePedido_Servicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidoProducto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDetallePedido = table.Column<long>(type: "bigint", nullable: false),
                    IdProducto = table.Column<short>(type: "smallint", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_[DetallePedidoProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallePedidoProducto_DetallePedido",
                        column: x => x.IdDetallePedido,
                        principalTable: "DetallePedido",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetallePedidoProducto_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdPedido",
                table: "Factura",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_IdPedido",
                table: "DetallePedido",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_IdServicio",
                table: "DetallePedido",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidoProducto_IdDetallePedido",
                table: "DetallePedidoProducto",
                column: "IdDetallePedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidoProducto_IdProducto",
                table: "DetallePedidoProducto",
                column: "IdProducto");

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
                name: "FK_Factura_Pedido",
                table: "Factura",
                column: "IdPedido",
                principalTable: "Pedido",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Pedido",
                table: "Factura");

            migrationBuilder.DropTable(
                name: "DetallePedidoProducto");

            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Factura_IdPedido",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "IdPedido",
                table: "Factura");
        }
    }
}
