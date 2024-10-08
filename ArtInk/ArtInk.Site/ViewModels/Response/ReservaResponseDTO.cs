﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Response;

public record ReservaResponseDto
{
    public int Id { get; set; }

    [DisplayFormat(DataFormatString = "{00}")]
    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public string Estado { get; set; } = null!;

    public bool Activo { get; set; }


    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }

    public short IdCliente { get; set; }

    [DisplayName("Cliente")]
    public string NombreCliente { get; set; } = null!;

    public virtual SucursalResponseDto Sucursal { get; set; } = null!;

    public virtual ClienteResponseDto Cliente { get; set; } = null!;

    [DisplayName("Preguntas")]
    public virtual ICollection<ReservaPreguntaResponseDto> ReservaPregunta { get; set; } = new List<ReservaPreguntaResponseDto>();

    [DisplayName("Servicio")]
    public virtual ICollection<ReservaServicioResponseDto> ReservaServicios { get; set; } = new List<ReservaServicioResponseDto>();

    public virtual ICollection<PedidoResponseDto> Pedidos { get; set; } = new List<PedidoResponseDto>();
}