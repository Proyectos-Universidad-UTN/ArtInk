﻿using System;
using System.Collections.Generic;

namespace ArtInk.Infraestructure.Models;

public partial class TipoPago
{
    public byte Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Referencia { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
