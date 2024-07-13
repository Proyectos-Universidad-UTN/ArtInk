namespace ArtInk.Application.DTOs;

public record SucursalHorarioDto
{
    public short Id { get; set; }

    public byte IdSucursal { get; set; }

    public short IdHorario { get; set; }

    public virtual HorarioDto Horario { get; set; } = null!;

    public virtual SucursalDto Sucursal { get; set; } = null!;

    public virtual ICollection<SucursalHorarioBloqueoDto> SucursalHorarioBloqueos { get; set; } = new List<SucursalHorarioBloqueoDto>();
}