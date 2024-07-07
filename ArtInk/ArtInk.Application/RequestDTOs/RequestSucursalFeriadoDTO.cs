namespace ArtInk.Application.RequestDTOs;

public record RequestSucursalFeriadoDTO
{
    public short Id { get; set; }

    public byte IdFeriado { get; set; }

    public byte IdSucursal { get; set; }

    public DateOnly Fecha { get; set; }

    public short Ano { get; set; }
}