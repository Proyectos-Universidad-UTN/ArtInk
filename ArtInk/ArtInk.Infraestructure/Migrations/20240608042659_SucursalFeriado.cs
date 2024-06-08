using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class SucursalFeriado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feriado_Sucursal",
                table: "Feriado");

            migrationBuilder.DropIndex(
                name: "IX_Feriado_IdSucursal",
                table: "Feriado");

            migrationBuilder.DropColumn(
                name: "IdSucursal",
                table: "Feriado");

            migrationBuilder.CreateTable(
                name: "SucursalFeriado",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFeriado = table.Column<byte>(type: "tinyint", nullable: false),
                    IdSucursal = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucursalFeriado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SucursalFeriado_Feriado",
                        column: x => x.IdFeriado,
                        principalTable: "Feriado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SucursalFeriado_Sucursal",
                        column: x => x.IdSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SucursalFeriado_IdFeriado",
                table: "SucursalFeriado",
                column: "IdFeriado");

            migrationBuilder.CreateIndex(
                name: "IX_SucursalFeriado_IdSucursal",
                table: "SucursalFeriado",
                column: "IdSucursal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SucursalFeriado");

            migrationBuilder.AddColumn<byte>(
                name: "IdSucursal",
                table: "Feriado",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_Feriado_IdSucursal",
                table: "Feriado",
                column: "IdSucursal");

            migrationBuilder.AddForeignKey(
                name: "FK_Feriado_Sucursal",
                table: "Feriado",
                column: "IdSucursal",
                principalTable: "Sucursal",
                principalColumn: "Id");
        }
    }
}
