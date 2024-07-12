using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record ContactoDto: BaseEntity
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int Telefono { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public byte IdProveedor { get; set; }

    public bool Activo { get; set; }

    public virtual ProveedorDto Proveedor { get; set; } = null!;
}