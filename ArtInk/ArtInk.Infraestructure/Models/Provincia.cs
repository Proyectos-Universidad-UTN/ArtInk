using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Provincia
{
    [Key]
    public byte Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("IdProvinciaNavigation")]
    public virtual ICollection<Canton> Canton { get; set; } = new List<Canton>();
}
