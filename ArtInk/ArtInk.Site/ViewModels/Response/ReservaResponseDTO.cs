using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Response;

public record ReservaResponseDto
{
    public int Id { get; set; }

    [DisplayFormat(DataFormatString = "{00}")]
    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public string Estado { get; set; } = null!;

    public bool Activo { get; set; }

    public short IdUsuarioSucursal { get; set; }

    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }

    public virtual UsuarioSucursalResponseDto UsuarioSucursal { get; set; } = null!;

    public virtual SucursalResponseDto Sucursal { get; set; } = null!;

    public virtual ICollection<ReservaPreguntaResponseDto> ReservaPreguntas { get; set; } = new List<ReservaPreguntaResponseDto>();

    public virtual ICollection<ReservaServicioResponseDto> ReservaServicios { get; set; } = new List<ReservaServicioResponseDto>();
}