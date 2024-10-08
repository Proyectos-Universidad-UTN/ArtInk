﻿namespace ArtInk.Infraestructure.Models;

public partial class Servicio: BaseModel
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public byte IdTipoServicio { get; set; }

    public decimal Tarifa { get; set; }

    public string? Observacion { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual TipoServicio IdTipoServicioNavigation{ get; set; } = null!;

    public virtual ICollection<ReservaServicio> ReservaServicios { get; set; } = new List<ReservaServicio>();
}