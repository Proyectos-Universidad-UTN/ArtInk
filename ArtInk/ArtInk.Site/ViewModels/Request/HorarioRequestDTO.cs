using ArtInk.Site.ViewModels.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Request;

public record HorarioRequestDto
{
    [Required(ErrorMessage = "Id requerido")]
    public short Id { get; set; }

    [DisplayName("Día")]
    [Required(ErrorMessage = "Día de la semana requerido")]
    public DiaSemana Dia { get; set; }

    [DisplayName("Hora Inicio")]
    [Required(ErrorMessage = "Hora de inicio requerido")]
    public TimeOnly HoraInicio { get; set; }

    [DisplayName("Hora Final")]
    [Required(ErrorMessage = "Hora de fin requerido")]
    public TimeOnly HoraFin { get; set; }
}