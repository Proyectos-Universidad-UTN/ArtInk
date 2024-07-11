namespace ArtInk.Site.ViewModels.Response;

public record SucursalHorarioBloqueoResponseDTO
{
    public long Id { get; set; }

    public short IdSucursalHorario { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public bool Activo { get; set; }

    public virtual SucursalHorarioResponseDTO SucursalHorario { get; set; } = null!;
}
