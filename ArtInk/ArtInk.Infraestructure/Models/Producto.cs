﻿namespace ArtInk.Infraestructure.Models;

public partial class Producto: BaseModel
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public byte IdCategoria { get; set; }

    public decimal Costo { get; set; }

    public string Sku { get; set; } = null!;

    public byte IdUnidadMedida { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<DetalleFacturaProducto> DetalleFacturaProductos { get; set; } = new List<DetalleFacturaProducto>();

    public virtual ICollection<DetallePedidoProducto> DetallePedidoProductos { get; set; } = new List<DetallePedidoProducto>();

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual UnidadMedida IdUnidadMedidaNavigation { get; set; } = null!;

    public virtual ICollection<InventarioProducto> InventarioProductos { get; set; } = new List<InventarioProducto>();
}