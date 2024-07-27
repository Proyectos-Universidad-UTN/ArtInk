using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record ReservaRequestDto
{
    public int Id { get; set; }

    [DisplayName("Fecha")]
    public DateOnly Fecha { get; set; }

    [DisplayName("Hora")]
    public TimeOnly Hora { get; set; }

    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }

    [DisplayName("Cliente")]
    public short IdCliente { get; set; }

    [DisplayName("Nombre del cliente")]
    public string NombreCliente { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public bool Activo { get; set; }

    public IEnumerable<SucursalResponseDto>? Sucursales { get; set; }

    public IEnumerable<ClienteResponseDto>? Clientes { get; set; }

    public List<ServicioResponseDto>? ServiciosReserva { get; set; } = new List<ServicioResponseDto>();

    public List<ServicioRequestDto>? Servicios { get; set; } = new List<ServicioRequestDto>();

    public IEnumerable<ReservaHorario>? Horarios { get; set; } = new List<ReservaHorario>();

    public List<ReservaPreguntaRequestDto>? ReservaPregunta { get; set; } = new List<ReservaPreguntaRequestDto>();
}