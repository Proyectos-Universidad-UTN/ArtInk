using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record FeriadoDTO : BaseEntity
{
    public byte Id { get; set; }

    public byte IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly? Fecha { get; set; }

    public bool Activo { get; set; }
}