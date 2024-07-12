using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArtInk.Site.ViewModels.Interfaces;
using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Common;

public record Direcciones : IDirecciones
{
    [NotMapped]
    public List<ProvinciaResponseDto> Provincias { get; set; } = new List<ProvinciaResponseDto>();

    [NotMapped]
    public List<CantonResponseDto> Cantones { get; set; } = new List<CantonResponseDto>();

    [NotMapped]
    public List<DistritoResponseDto> Distritos { get; set; } = new List<DistritoResponseDto>();

    [NotMapped]
    [DisplayName("Provincia")]
    [Required(ErrorMessage = "La provincia es requerida")]
    [Range(minimum: 1, maximum: 1000, ErrorMessage = "Por favor seleccione una provincia")]
    public byte IdProvincia { get; set; }

    [DisplayName("Cantón")]
    [NotMapped]
    [Required(ErrorMessage = "El cantón es requerido")]
    [Range(minimum: 1, maximum: 1000, ErrorMessage = "Por favor seleccione un cantón")]
    public byte IdCanton { get; set; }

    [DisplayName("Distrito")]
    [Required(ErrorMessage = "El distrito es requerido")]
    [Range(minimum: 1, maximum: 1000, ErrorMessage = "Por favor seleccione un distrito")]
    public short IdDistrito { get; set; }
}