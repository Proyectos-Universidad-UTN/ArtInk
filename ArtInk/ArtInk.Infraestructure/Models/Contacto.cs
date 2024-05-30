﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Contacto
{
    [Key]
    public short Id { get; set; }

    [StringLength(80)]
    public string Nombre { get; set; } = null!;

    [StringLength(80)]
    public string Apellidos { get; set; } = null!;

    public int Telefono { get; set; }

    [StringLength(150)]
    public string CorreoElectronico { get; set; } = null!;

    public byte IdProveedor { get; set; }

    public bool Activo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(70)]
    public string UsuarioCreacion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaModifiacion { get; set; }

    [StringLength(70)]
    public string? UsuarioModificacion { get; set; }

    [ForeignKey("IdProveedor")]
    [InverseProperty("Contacto")]
    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
