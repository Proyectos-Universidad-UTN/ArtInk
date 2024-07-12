using ArtInk.Infraestructure.Enums;

namespace ArtInk.Infraestructure.Models;

public partial class Horario
{
    public short Id { get; set; }

    public DiaSemana Dia { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<SucursalHorario> SucursalHorarios { get; set; } = new List<SucursalHorario>();
}