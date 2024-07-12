namespace ArtInk.Site.ViewModels.Response;

public record SucursalHorarioBloqueoResponseDto
{
    public long Id { get; set; }

    public short IdSucursalHorario { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public bool Activo { get; set; }

    public virtual SucursalHorarioResponseDto SucursalHorario { get; set; } = null!;
}
