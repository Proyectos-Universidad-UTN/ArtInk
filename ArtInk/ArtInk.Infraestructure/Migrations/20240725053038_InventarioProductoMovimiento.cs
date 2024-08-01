using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InventarioProductoMovimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Minima",
                table: "InventarioProducto",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Maxima",
                table: "InventarioProducto",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Disponible",
                table: "InventarioProducto",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateTable(
                name: "InventarioProductoMovimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInventarioProducto = table.Column<long>(type: "bigint", nullable: false),
                    TipoMovimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioProductoMovimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventarioProductoMovimiento_InventarioProducto",
                        column: x => x.IdInventarioProducto,
                        principalTable: "InventarioProducto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventarioProductoMovimiento_IdInventarioProducto",
                table: "InventarioProductoMovimiento",
                column: "IdInventarioProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventarioProductoMovimiento");

            migrationBuilder.AlterColumn<byte>(
                name: "Minima",
                table: "InventarioProducto",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<byte>(
                name: "Maxima",
                table: "InventarioProducto",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<byte>(
                name: "Disponible",
                table: "InventarioProducto",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
