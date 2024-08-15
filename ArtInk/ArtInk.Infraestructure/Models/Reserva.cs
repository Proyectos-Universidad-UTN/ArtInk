using System.ComponentModel.DataAnnotations;

namespace ArtInk.Infraestructure.Models;

public partial class Reserva: BaseModel
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public short IdUsuarioSucursal { get; set; }

    public byte IdSucursal { get; set; }

    public short IdCliente { get; set; }

    [StringLength(80)]
    public string NombreCliente { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual UsuarioSucursal IdUsuarioSucursalNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<ReservaPregunta> ReservaPregunta { get; set; } = new List<ReservaPregunta>();

    public virtual ICollection<ReservaServicio> ReservaServicios { get; set; } = new List<ReservaServicio>();
    
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}