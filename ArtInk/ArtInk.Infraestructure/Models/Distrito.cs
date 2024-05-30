using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Distrito
{
    [Key]
    public short Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    public byte IdCanton { get; set; }

    [InverseProperty("IdDistritoNavigation")]
    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();

    [ForeignKey("IdCanton")]
    [InverseProperty("Distrito")]
    public virtual Canton IdCantonNavigation { get; set; } = null!;

    [InverseProperty("IdDistritoNavigation")]
    public virtual ICollection<Proveedor> Proveedor { get; set; } = new List<Proveedor>();

    [InverseProperty("IdDistritoNavigation")]
    public virtual ICollection<Sucursal> Sucursal { get; set; } = new List<Sucursal>();

    [InverseProperty("IdDistritoNavigation")]
    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
