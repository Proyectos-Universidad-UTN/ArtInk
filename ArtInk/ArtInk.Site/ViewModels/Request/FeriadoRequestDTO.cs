using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ArtInk.Site.ViewModels.Common;

namespace ArtInk.Site.ViewModels.Request;

public record FeriadoRequestDto
{
    [JsonRequired]
    public byte Id { get; set; }

    [DisplayName("Nombre")]
    [Required(ErrorMessage = "Debe ingresar el nombre del feriado")]
    [MaxLength(80)]
    public string Nombre { get; set; } = null!;

    [JsonRequired]
    public bool Activo { get; set; }
    
    [JsonRequired]
    public Mes Mes { get; set; }

    [Required(ErrorMessage = "Debe ingresar el día")]
    [Range(1, 31, ErrorMessage = "Solo se permiten dias entre 1 y 31")]
    public byte Dia { get; set; }
}