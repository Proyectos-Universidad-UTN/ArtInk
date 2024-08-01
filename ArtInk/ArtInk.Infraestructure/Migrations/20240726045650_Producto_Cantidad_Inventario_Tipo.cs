using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Producto_Cantidad_Inventario_Tipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Producto");

            migrationBuilder.AddColumn<string>(
                name: "TipoInventario",
                table: "Inventario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoInventario",
                table: "Inventario");

            migrationBuilder.AddColumn<decimal>(
                name: "Cantidad",
                table: "Producto",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
