using System.ComponentModel;
using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record InventarioDto: BaseEntity
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }

    public bool Activo { get; set; }

    public virtual SucursalDto Sucursal { get; set; } = null!;

    public virtual ICollection<InventarioProductoDto> InventarioProductos { get; set; } = new List<InventarioProductoDto>();
}