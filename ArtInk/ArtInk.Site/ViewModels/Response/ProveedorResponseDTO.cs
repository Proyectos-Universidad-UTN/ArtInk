using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record ProveedorResponseDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Cédula Jurídica")]
    public string CedulaJuridica { get; set; } = null!;

    [DisplayName("Razón Social")]
    public string RasonSocial { get; set; } = null!;

    [DisplayName("Teléfono")]
    public int Telefono { get; set; }

    [DisplayName("Correo Electrónico")]
    public string CorreoElectronico { get; set; } = null!;

    [DisplayName("Distrito")]
    public short IdDistrito { get; set; }

    [DisplayName("Dirección")]
    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<ContactoResponseDto> Contactos { get; set; } = new List<ContactoResponseDto>();

    public virtual DistritoResponseDto Distrito { get; set; } = null!;
}