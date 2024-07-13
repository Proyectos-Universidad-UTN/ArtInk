using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InventarioProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventario_Producto",
                table: "Inventario");

            migrationBuilder.DropIndex(
                name: "IX_Inventario_IdProducto",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "Disponible",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "Maxima",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "Minima",
                table: "Inventario");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Inventario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Inventario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "InventarioProducto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInventario = table.Column<short>(type: "smallint", nullable: false),
                    IdProducto = table.Column<short>(type: "smallint", nullable: false),
                    Disponible = table.Column<byte>(type: "tinyint", nullable: false),
                    Minima = table.Column<byte>(type: "tinyint", nullable: false),
                    Maxima = table.Column<byte>(type: "tinyint", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventarioProducto_Inventario",
                        column: x => x.IdInventario,
                        principalTable: "Inventario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventarioProducto_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventarioProducto_IdInventario",
                table: "InventarioProducto",
                column: "IdInventario");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioProducto_IdProducto",
                table: "InventarioProducto",
                column: "IdProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventarioProducto");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Inventario");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Inventario");

            migrationBuilder.AddColumn<byte>(
                name: "Disponible",
                table: "Inventario",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "IdProducto",
                table: "Inventario",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<byte>(
                name: "Maxima",
                table: "Inventario",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Minima",
                table: "Inventario",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdProducto",
                table: "Inventario",
                column: "IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventario_Producto",
                table: "Inventario",
                column: "IdProducto",
                principalTable: "Producto",
                principalColumn: "Id");
        }
    }
}
