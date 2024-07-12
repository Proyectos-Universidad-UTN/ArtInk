using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record ClienteResponseDto
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    [DisplayName("Correo Electrónico")]
    public string CorreoElectronico { get; set; } = null!;

    [DisplayName("Teléfono")]
    public int Telefono { get; set; }

    [DisplayName("Distrito")]
    public short IdDistrito { get; set; }

    [DisplayName("Dirección")]
    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<FacturaResponseDto> Facturas { get; set; } = new List<FacturaResponseDto>();

    public virtual DistritoResponseDto Distrito { get; set; } = null!;
}