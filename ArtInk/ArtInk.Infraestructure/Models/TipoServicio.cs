﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class TipoServicio
{
    [Key]
    public byte Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    public TimeOnly Duracion { get; set; }

    [InverseProperty("IdTipoServicioNavigation")]
    public virtual ICollection<Servicio> Servicio { get; set; } = new List<Servicio>();
}
