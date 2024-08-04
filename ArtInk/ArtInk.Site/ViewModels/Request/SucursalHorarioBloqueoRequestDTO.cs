using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Request;

public record SucursalHorarioBloqueoRequestDto
{
    public long Id { get; set; }

    [DisplayName("Sucursal Horario")]
    public short IdSucursalHorario { get; set; }

    [Required(ErrorMessage = "Por favor ingrese la hora de inicio")]
    [DataType(DataType.Time)]
    [DisplayName("Hora de Inicio")]
    public TimeOnly HoraInicio { get; set; }

    [Required(ErrorMessage = "Por favor ingrese la hora de fin")]
    [DataType(DataType.Time)]
    [DisplayName("Hora de Fin")]
    public TimeOnly HoraFin { get; set; }
}
