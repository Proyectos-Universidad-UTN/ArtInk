using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record ContactoResponseDto
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    [DisplayName("Teléfono")]
    public int Telefono { get; set; }

    [DisplayName("Correo electrónico")]
    public string CorreoElectronico { get; set; } = null!;

    [DisplayName("Proveedor")]
    public byte IdProveedor { get; set; }

    public bool Activo { get; set; }

    public virtual ProveedorResponseDto Proveedor { get; set; } = null!;
}