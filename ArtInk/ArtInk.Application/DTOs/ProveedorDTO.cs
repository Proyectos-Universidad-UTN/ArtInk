using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record ProveedorDTO: BaseEntity
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string CedulaJuridica { get; set; } = null!;

    public string RasonSocial { get; set; } = null!;

    public int Telefono { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public short IdDistrito { get; set; }

    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<ContactoDTO> Contactos { get; set; } = new List<ContactoDTO>();

    public virtual DistritoDTO Distrito { get; set; } = null!;
}