﻿namespace ArtInk.Infraestructure.Models;

public partial class Sucursal: BaseModel
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Telefono { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public short IdDistrito { get; set; }

    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }

    public virtual Distrito IdDistritoNavigation { get; set; } = null!;

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<SucursalHorario> SucursalHorarios { get; set; } = new List<SucursalHorario>();

    public virtual ICollection<UsuarioSucursal> UsuarioSucursals { get; set; } = new List<UsuarioSucursal>();

    public virtual ICollection<SucursalFeriado> SucursalFeriados { get; set; } = new List<SucursalFeriado>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}