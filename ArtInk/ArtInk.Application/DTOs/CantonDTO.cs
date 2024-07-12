using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtInk.Application.DTOs;

public record CantonDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public byte IdProvincia { get; set; }

    public virtual ICollection<DistritoDto> Distritos { get; set; } = new List<DistritoDto>();

    public virtual ProvinciaDto Provincia { get; set; } = null!;
}