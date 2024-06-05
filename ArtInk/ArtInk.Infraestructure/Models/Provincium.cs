using System;
using System.Collections.Generic;

namespace ArtInk.Infraestructure.Models;

public partial class Provincium
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Canton> Cantons { get; set; } = new List<Canton>();
}
