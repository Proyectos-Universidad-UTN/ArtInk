using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ArtInk.Site.ViewModels.Common;

namespace ArtInk.Site.ViewModels.Request;

public record FeriadoRequestDto
{
    public byte Id { get; set; }

    [DisplayName("Nombre")]
    [Required(ErrorMessage = "Debe ingresar el nombre del feriado")]
    [MaxLength(80)]
    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public Mes Mes { get; set; }

    [Required(ErrorMessage = "Debe ingresar el día")]
    [Range(1, 31, ErrorMessage = "Solo se permiten dias entre 1 y 31")]
    public byte Dia { get; set; }
}