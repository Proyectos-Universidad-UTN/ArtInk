using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class SucursalHorarioBloqueo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SucursalHorarioBloqueo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSucursalHorario = table.Column<short>(type: "smallint", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeOnly>(type: "time", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucursalHorarioBloqueo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SucursalHorarioBloqueo_SucursalHorario",
                        column: x => x.IdSucursalHorario,
                        principalTable: "SucursalHorario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SucursalHorarioBloqueo_IdSucursalHorario",
                table: "SucursalHorarioBloqueo",
                column: "IdSucursalHorario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SucursalHorarioBloqueo");
        }
    }
}
