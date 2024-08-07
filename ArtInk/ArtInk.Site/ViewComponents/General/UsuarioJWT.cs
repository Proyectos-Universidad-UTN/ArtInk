namespace ArtInk.Site.ViewComponents.General;

public class UsuarioJWT
{
    public short IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Role { get; set; } = null!;
}