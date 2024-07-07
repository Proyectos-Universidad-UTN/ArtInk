using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtInk.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Feriado_Fechas_Sucursal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Feriado");

            migrationBuilder.AddColumn<short>(
                name: "Ano",
                table: "SucursalFeriado",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Fecha",
                table: "SucursalFeriado",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<byte>(
                name: "Dia",
                table: "Feriado",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Mes",
                table: "Feriado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                table: "SucursalFeriado");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "SucursalFeriado");

            migrationBuilder.DropColumn(
                name: "Dia",
                table: "Feriado");

            migrationBuilder.DropColumn(
                name: "Mes",
                table: "Feriado");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Fecha",
                table: "Feriado",
                type: "date",
                nullable: true);
        }
    }
}
