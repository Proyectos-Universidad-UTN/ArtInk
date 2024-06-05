using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtInk.Application.DTOs;

public record CantonDTO
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public byte IdProvincia { get; set; }

    public virtual ICollection<DistritoDTO> Distritos { get; set; } = new List<DistritoDTO>();

    public virtual ProvinciaDTO Provincia { get; set; } = null!;
}