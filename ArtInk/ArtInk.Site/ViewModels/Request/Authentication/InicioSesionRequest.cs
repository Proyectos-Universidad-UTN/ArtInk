using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Request.Authentication;

public class InicioSesionRequest
{
    [Display(Name = "Correo electrónico")]
    [Required(ErrorMessage = "Correo electrónico requerido")]
    [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
    public string CorreoElectronico { get; set; } = null!;

    [Display(Name = "Contraseña")]
    [Required(ErrorMessage = "Contraseña requerida")]
    public string Contrasenna { get; set; } = null!;
}