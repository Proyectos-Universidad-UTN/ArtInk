using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ArtInk.Site.ViewModels.Common;

namespace ArtInk.Site.ViewModels.Request;

public record ProveedorRequestDto : Direcciones
{
    [JsonRequired]
    public byte Id { get; set; }

    [Required(ErrorMessage = "Nombre requerido")]
    public string Nombre { get; set; } = null!;

    [DisplayName("Cédula Jurídica")]
    [Required(ErrorMessage = "Cédula Jurídica requerida")]
    [RegularExpression(@"^\d{1}\-\d{3}\-\d{6}$", ErrorMessage = "Por favor complete la cédula jurídica")]
    public string CedulaJuridica { get; set; } = null!;


    [DisplayName("Rason Social")]
    [Required(ErrorMessage = "Rason Social requerido")]
    public string RasonSocial { get; set; } = null!;

    [JsonRequired]
    public int Telefono
    {
        get => !string.IsNullOrEmpty(TelefonoFormateado) ? int.Parse(TelefonoFormateado.Replace("-", "")) : 0;
        set => TelefonoFormateado = value.ToString();
    }

    [DisplayName("Teléfono")]
    [Required(ErrorMessage = "El teléfono es requerido")]
    [RegularExpression(@"^\d{4}\-\d{4}$", ErrorMessage = "Por favor complete el teléfono")]
    [MaxLength(9)]
    public string TelefonoFormateado { get; set; } = string.Empty;

    [DisplayName("Correo Electrónico")]
    [Required(ErrorMessage = "Correo electrónico requerido")]
    [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
    public string CorreoElectronico { get; set; } = null!;

    [DisplayName("Dirección Exacta")]
    [Required(ErrorMessage = "Dirección exacta requerida")]
    public string? DireccionExacta { get; set; }

    [JsonRequired]
    public bool Activo { get; set; }
}