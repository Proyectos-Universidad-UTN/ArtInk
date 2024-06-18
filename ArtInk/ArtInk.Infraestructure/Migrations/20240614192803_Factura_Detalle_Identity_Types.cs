using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Factura_Detalle_Identity_Types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFacturaProducto_DetalleFactura",
                table: "DetalleFacturaProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_[DetalleFacturaProducto",
                table: "DetalleFacturaProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFactura_Factura",
                table: "DetalleFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalleFactura",
                table: "DetalleFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_factura",
                table: "Factura");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Factura",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "IdDetalleFactura",
                table: "DetalleFacturaProducto",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "DetalleFacturaProducto",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "IdFactura",
                table: "DetalleFactura",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "DetalleFactura",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_factura",
                table: "Factura",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleFactura",
                table: "DetalleFactura",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleFacturaProducto",
                table: "DetalleFacturaProducto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFacturaProducto_DetalleFactura",
                table: "DetalleFacturaProducto",
                principalTable: "DetalleFactura",
                column: "IdDetalleFactura",
                onDelete: ReferentialAction.Restrict,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFactura_Factura",
                table: "DetalleFactura",
                principalTable: "Factura",
                column: "IdFactura",
                onDelete: ReferentialAction.Restrict,
                onUpdate: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFacturaProducto_DetalleFactura",
                table: "DetalleFacturaProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_[DetalleFacturaProducto",
                table: "DetalleFacturaProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFactura_Factura",
                table: "DetalleFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalleFactura",
                table: "DetalleFactura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_factura",
                table: "Factura");

            migrationBuilder.AlterColumn<short>(
                name: "Id",
                table: "Factura",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<short>(
                name: "IdDetalleFactura",
                table: "DetalleFacturaProducto",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<short>(
                name: "Id",
                table: "DetalleFacturaProducto",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<short>(
                name: "IdFactura",
                table: "DetalleFactura",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<short>(
                name: "Id",
                table: "DetalleFactura",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_factura",
                table: "Factura",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleFactura",
                table: "DetalleFactura",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleFacturaProducto",
                table: "DetalleFacturaProducto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFacturaProducto_DetalleFactura",
                table: "DetalleFacturaProducto",
                principalTable: "DetalleFactura",
                column: "IdDetalleFactura",
                onDelete: ReferentialAction.Restrict,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFactura_Factura",
                table: "DetalleFactura",
                principalTable: "Factura",
                column: "IdFactura",
                onDelete: ReferentialAction.Restrict,
                onUpdate: ReferentialAction.NoAction);  

        }
    }
}
