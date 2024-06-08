using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record InventarioDTO: BaseEntity
{
    public short Id { get; set; }

    public byte IdSucursal { get; set; }

    public short IdProducto { get; set; }

    public byte Disponible { get; set; }

    public byte Minima { get; set; }

    public byte Maxima { get; set; }

    public virtual ProductoDTO Producto { get; set; } = null!;

    public virtual SucursalDTO Sucursal { get; set; } = null!;
}