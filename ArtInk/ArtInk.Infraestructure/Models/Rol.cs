using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Rol
{
    [Key]
    public byte Id { get; set; }

    [StringLength(50)]
    public string Descripcion { get; set; } = null!;

    [StringLength(50)]
    public string Tipo { get; set; } = null!;

    public bool Activo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(70)]
    public string UsuarioCreacion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    [StringLength(70)]
    public string? UsuarioModificacion { get; set; }

    [InverseProperty("IdRolNavigation")]
    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
