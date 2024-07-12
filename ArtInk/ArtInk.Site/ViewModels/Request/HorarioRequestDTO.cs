using ArtInk.Site.ViewModels.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ArtInk.Site.ViewModels.Request;

public record HorarioRequestDto
{
    [JsonRequired]
    public short Id { get; set; }

    [DisplayName("Día")]
    [Required(ErrorMessage = "Día de la semana requerido")]
    [JsonRequired]
    public DiaSemana Dia { get; set; }

    [DisplayName("Hora Inicio")]
    [Required(ErrorMessage = "Hora de inicio requerido")]
    [JsonRequired]
    public TimeOnly HoraInicio { get; set; }

    [DisplayName("Hora Final")]
    [Required(ErrorMessage = "Hora de fin requerido")]
    [JsonRequired]
    public TimeOnly HoraFin { get; set; }
}