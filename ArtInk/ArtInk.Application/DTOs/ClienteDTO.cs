using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record ClienteDto: BaseEntity
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public int Telefono { get; set; }

    public short IdDistrito { get; set; }

    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<FacturaDto> Facturas { get; set; } = new List<FacturaDto>();

    public virtual DistritoDto Distrito { get; set; } = null!;
}