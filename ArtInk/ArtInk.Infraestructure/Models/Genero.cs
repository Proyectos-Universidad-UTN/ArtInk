using System;
using System.Collections.Generic;

namespace ArtInk.Infraestructure.Models;

public partial class Genero
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
