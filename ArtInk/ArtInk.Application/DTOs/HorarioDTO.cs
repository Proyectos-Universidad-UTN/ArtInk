using ArtInk.Application.DTOs.Base;
using ArtInk.Infraestructure.Enums;

namespace ArtInk.Application.DTOs;

public record HorarioDTO : BaseEntity
{
    public short Id { get; set; }

    public DiaSemana Dia { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public virtual ICollection<SucursalHorarioDTO> SucursalHorarios { get; set; } = new List<SucursalHorarioDTO>();
}