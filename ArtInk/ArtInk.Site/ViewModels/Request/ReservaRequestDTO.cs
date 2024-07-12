using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record ReservaRequestDto
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    [DisplayName("Horario")]
    public short IdSucursalHorario { get; set; }

    public string Estado { get; set; } = null!;

    public bool Activo { get; set; }
}