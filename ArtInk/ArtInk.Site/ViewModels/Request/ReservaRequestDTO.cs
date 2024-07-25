using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record ReservaRequestDto
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public short IdSucursalHorario { get; set; }

    public byte IdSucursal { get; set; }

    public string Estado { get; set; } = null!;

    public bool Activo { get; set; }

    public IEnumerable<SucursalResponseDto>? Sucursales { get; set; }
}