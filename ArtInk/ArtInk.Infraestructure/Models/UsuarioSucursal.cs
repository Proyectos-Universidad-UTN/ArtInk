using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class UsuarioSucursal
{
    [Key]
    public short Id { get; set; }

    public short IdUsuario { get; set; }

    public byte IdSucursal { get; set; }

    [InverseProperty("IdUsuarioSucursalNavigation")]
    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

    [ForeignKey("IdSucursal")]
    [InverseProperty("UsuarioSucursal")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("UsuarioSucursal")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
