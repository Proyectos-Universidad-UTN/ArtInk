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

    public virtual ReservaDTO IdReservaNavigation { get; set; } = null!;

    public virtual ServicioDTO IdServicioNavigation { get; set; } = null!;
}