using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record InventarioDTO: BaseEntity
{
    public short Id { get; set; }

    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }

    [DisplayName("Producto")]
    public short IdProducto { get; set; }

    public byte Disponible { get; set; }

    [DisplayName("Mínima")]
    public byte Minima { get; set; }

    [DisplayName("Máxima")]
    public byte Maxima { get; set; }

    public virtual ProductoDTO Producto { get; set; } = null!;

    public virtual SucursalDTO Sucursal { get; set; } = null!;
}