using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record ReservaDto: BaseEntity
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public short IdSucursalHorario { get; set; }

    public byte IdSucursal { get; set; }

    public string Estado { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual UsuarioSucursalDto UsuarioSucursal { get; set; } = null!;

    public virtual SucursalDto Sucursal { get; set; } = null!;

    public virtual ICollection<ReservaPreguntaDto> ReservaPregunta { get; set; } = new List<ReservaPreguntaDto>();

    public virtual ICollection<ReservaServicioDto> ReservaServicios { get; set; } = new List<ReservaServicioDto>();
}