using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class UnidadMedida
{
    [Key]
    public byte Id { get; set; }

    [StringLength(25)]
    public string Nombre { get; set; } = null!;

    [StringLength(5)]
    public string Simbolo { get; set; } = null!;

    [InverseProperty("IdUnidadMedidaNavigation")]
    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
