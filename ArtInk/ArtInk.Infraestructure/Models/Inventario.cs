using ArtInk.Infraestructure.Enums;

namespace ArtInk.Infraestructure.Models;

public partial class Inventario: BaseModel
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public byte IdSucursal { get; set; }

    public TipoInventario TipoInventario { get; set; }

    public bool Activo { get; set; }
    
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    public virtual ICollection<InventarioProducto> InventarioProductos { get; set; } = new List<InventarioProducto>();
}