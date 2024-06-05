using System;
using System.Collections.Generic;

namespace ArtInk.Infraestructure.Models;

public partial class Canton
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public byte IdProvincia { get; set; }

    public virtual ICollection<Distrito> Distritos { get; set; } = new List<Distrito>();

    public virtual Provincium IdProvinciaNavigation { get; set; } = null!;
}
