using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Response;

public record SucursalResponseDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Descripción")]
    public string Descripcion { get; set; } = null!;

    [DisplayName("Teléfono")]
    [DisplayFormat(DataFormatString = "{0:####-####}")]
    public int Telefono { get; set; }

    [DisplayName("Correo Electrónico")]
    public string CorreoElectronico { get; set; } = null!;

    [DisplayName("Distrito")]
    public short IdDistrito { get; set; }

    [DisplayName("Dirección")]
    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<HorarioResponseDto> Horarios { get; set; } = new List<HorarioResponseDto>();

    public virtual DistritoResponseDto Distrito { get; set; } = null!;

    public virtual ICollection<InventarioResponseDto> Inventarios { get; set; } = new List<InventarioResponseDto>();

    public virtual ICollection<SucursalHorarioResponseDto> SucursalHorarios { get; set; } = new List<SucursalHorarioResponseDto>();

    [DisplayName("Encargados")]
    public virtual ICollection<UsuarioSucursalResponseDto> UsuarioSucursals { get; set; } = new List<UsuarioSucursalResponseDto>();

    public virtual ICollection<SucursalFeriadoResponseDto> SucursalFeriados { get; set; } = new List<SucursalFeriadoResponseDto>();

    public virtual ICollection<ReservaResponseDto> Reservas { get; set; } = new List<ReservaResponseDto>();

    public virtual ICollection<PedidoResponseDto> Pedidos { get; set; } = new List<PedidoResponseDto>();

    public virtual ICollection<FacturaResponseDto> Facturas { get; set; } = new List<FacturaResponseDto>();
}