using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record SucursalHorarioResponseDto
{
    public short Id { get; set; }

    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }

    [DisplayName("Horario")]
    public short IdHorario { get; set; }

    public virtual HorarioResponseDto Horario { get; set; } = null!;

    public virtual SucursalResponseDto Sucursal { get; set; } = null!;
}