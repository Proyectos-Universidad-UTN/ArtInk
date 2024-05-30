using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class TipoPago
{
    [Key]
    public byte Id { get; set; }

    [StringLength(50)]
    public string Descripcion { get; set; } = null!;

    public int Referencia { get; set; }

    [InverseProperty("IdTipoPagoNavigation")]
    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();
}
