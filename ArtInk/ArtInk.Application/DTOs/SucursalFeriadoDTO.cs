namespace ArtInk.Application.DTOs;

public record SucursalFeriadoDTO
{
    public short Id { get; set; }

    public byte IdFeriado { get; set; }

    public byte IdSucursal { get; set; }

    public DateOnly Fecha { get; set; }

    public short Ano { get; set; }

    public virtual FeriadoDTO Feriado { get; set; } = null!;

    public virtual SucursalDTO Sucursal { get; set; } = null!;
}