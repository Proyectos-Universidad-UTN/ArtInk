using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Canton
{
    [Key]
    public byte Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    public byte IdProvincia { get; set; }

    [InverseProperty("IdCantonNavigation")]
    public virtual ICollection<Distrito> Distrito { get; set; } = new List<Distrito>();

    [ForeignKey("IdProvincia")]
    [InverseProperty("Canton")]
    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;
}
