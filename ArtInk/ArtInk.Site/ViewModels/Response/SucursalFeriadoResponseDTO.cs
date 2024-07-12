using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record SucursalFeriadoResponseDto
{
    public short Id { get; set; }

    [DisplayName("Feriado")]
    public byte IdFeriado { get; set; }

    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }

    public DateOnly Fecha { get; set; }

    public short Anno { get; set; }

    public virtual FeriadoResponseDto Feriado { get; set; } = null!;

    public virtual SucursalResponseDto Sucursal { get; set; } = null!;
}