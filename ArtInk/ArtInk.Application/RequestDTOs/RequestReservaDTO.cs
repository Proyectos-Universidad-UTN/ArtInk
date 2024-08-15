﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ArtInk.Application.RequestDTOs;

public record RequestReservaDto: RequestBaseDto
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public short IdUsuarioSucursal { get; set; }

    public byte IdSucursal { get; set; }

    public short IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public bool Activo { get; set; }

    public List<RequestReservaPreguntaDto> ReservaPregunta { get; set; } = null!;

    public List<RequestReservaServicioDto> ReservaServicios { get; set; } = null!;
}