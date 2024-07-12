using ArtInk.Application.DTOs.Base;
using ArtInk.Application.DTOs.Enums;

namespace ArtInk.Application.DTOs;

public record FeriadoDto : BaseEntity
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public Mes Mes { get; set; }

    public byte Dia { get; set; }

    public virtual ICollection<SucursalFeriadoDto> SucursalFeriados { get; set; } = new List<SucursalFeriadoDto>();
}