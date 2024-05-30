using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Genero
{
    [Key]
    public byte Id { get; set; }

    [StringLength(25)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("IdGeneroNavigation")]
    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
