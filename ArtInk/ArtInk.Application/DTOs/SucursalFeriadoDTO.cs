namespace ArtInk.Application.DTOs;

public record SucursalFeriadoDto
{
    public short Id { get; set; }

    public byte IdFeriado { get; set; }

    public byte IdSucursal { get; set; }

    public DateOnly Fecha { get; set; }

    public short Anno { get; set; }

    public virtual FeriadoDto Feriado { get; set; } = null!;

    public virtual SucursalDto Sucursal { get; set; } = null!;
}