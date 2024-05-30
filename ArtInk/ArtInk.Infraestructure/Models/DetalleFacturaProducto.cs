using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class DetalleFacturaProducto
{
    [Key]
    public short Id { get; set; }

    public short IdDetalleFactura { get; set; }

    public short IdProducto { get; set; }

    public short Cantidad { get; set; }

    public short CantidadUsada { get; set; }

    [ForeignKey("IdDetalleFactura")]
    [InverseProperty("DetalleFacturaProducto")]
    public virtual DetalleFactura IdDetalleFacturaNavigation { get; set; } = null!;

    [ForeignKey("IdProducto")]
    [InverseProperty("DetalleFacturaProducto")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
