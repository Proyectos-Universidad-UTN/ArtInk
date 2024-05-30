using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class ServicioProducto
{
    [Key]
    public short Id { get; set; }

    public byte IdServicio { get; set; }

    public short IdProducto { get; set; }

    public short Cantidad { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("ServicioProducto")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;

    [ForeignKey("IdServicio")]
    [InverseProperty("ServicioProducto")]
    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
