using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtInk.Application.DTOs;

public record ReservaServicioDTO 
{
    public int Id { get; set; }

    public int IdReserva { get; set; }

    public byte IdServicio { get; set; }

    public virtual ReservaDTO ReservaNav { get; set; } = null!;

    public virtual ServicioDTO ServicioNav { get; set; } = null!;
}