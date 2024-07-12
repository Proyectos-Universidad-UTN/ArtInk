using ArtInk.Application.DTOs.Base;
using ArtInk.Infraestructure.Enums;

namespace ArtInk.Application.DTOs;

public record HorarioDto : BaseEntity
{
    public short Id { get; set; }

    public DiaSemana Dia { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public virtual ICollection<SucursalHorarioDto> SucursalHorarios { get; set; } = new List<SucursalHorarioDto>();
}