using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Proveedor
{
    [Key]
    public byte Id { get; set; }

    [StringLength(80)]
    public string Nombre { get; set; } = null!;

    [StringLength(20)]
    public string CedulaJuridica { get; set; } = null!;

    [StringLength(150)]
    public string RasonSocial { get; set; } = null!;

    public int Telefono { get; set; }

    [StringLength(150)]
    public string CorreoElectronico { get; set; } = null!;

    public short IdDistrito { get; set; }

    [StringLength(250)]
    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(70)]
    public string UsuarioCreacion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    [StringLength(70)]
    public string? UsuarioModificacion { get; set; }

    [InverseProperty("IdProveedorNavigation")]
    public virtual ICollection<Contacto> Contacto { get; set; } = new List<Contacto>();

    [ForeignKey("IdDistrito")]
    [InverseProperty("Proveedor")]
    public virtual Distrito IdDistritoNavigation { get; set; } = null!;
}
