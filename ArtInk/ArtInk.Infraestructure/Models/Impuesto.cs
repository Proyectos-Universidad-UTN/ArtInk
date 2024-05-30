using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Impuesto
{
    [Key]
    public byte Id { get; set; }

    [StringLength(40)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Porcentaje { get; set; }

    [InverseProperty("IdImpuestoNavigation")]
    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();
}
