using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Cliente
{
    [Key]
    public short Id { get; set; }

    [StringLength(80)]
    public string Nombre { get; set; } = null!;

    [StringLength(80)]
    public string Apellidos { get; set; } = null!;

    [StringLength(150)]
    public string CorreoElectronico { get; set; } = null!;

    public int Telefono { get; set; }

    public short IdDistrito { get; set; }

    [StringLength(250)]
    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(70)]
    public string? UsuarioCreacion { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    [StringLength(70)]
    public string? UsuarioModificacion { get; set; }

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

    [ForeignKey("IdDistrito")]
    [InverseProperty("Cliente")]
    public virtual Distrito IdDistritoNavigation { get; set; } = null!;
}
