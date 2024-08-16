using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record SucursalDto: BaseEntity
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Telefono { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public short IdDistrito { get; set; }

    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }

    public virtual DistritoDto? Distrito { get; set; } = null!;

    public virtual ICollection<InventarioDto> Inventarios { get; set; } = new List<InventarioDto>();

    public virtual ICollection<SucursalHorarioDto> SucursalHorarios { get; set; } = new List<SucursalHorarioDto>();

    public virtual ICollection<UsuarioSucursalDto> UsuarioSucursals { get; set; } = new List<UsuarioSucursalDto>();

    public virtual ICollection<SucursalFeriadoDto> SucursalFeriados { get; set; } = new List<SucursalFeriadoDto>();

    public virtual ICollection<ReservaDto> Reservas { get; set; } = new List<ReservaDto>();

    public virtual ICollection<PedidoDto> Pedidos { get; set; } = new List<PedidoDto>();

    public virtual ICollection<FacturaDto> Facturas { get; set; } = new List<FacturaDto>();
}