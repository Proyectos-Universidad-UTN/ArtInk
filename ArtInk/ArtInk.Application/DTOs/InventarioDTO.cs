using System.ComponentModel;
using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record InventarioDto: BaseEntity
{
    public short Id { get; set; }

    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }

    [DisplayName("Producto")]
    public short IdProducto { get; set; }

    public byte Disponible { get; set; }

    [DisplayName("M�nima")]
    public byte Minima { get; set; }

    [DisplayName("M�xima")]
    public byte Maxima { get; set; }

    public virtual ProductoDto Producto { get; set; } = null!;

    public virtual SucursalDto Sucursal { get; set; } = null!;
}