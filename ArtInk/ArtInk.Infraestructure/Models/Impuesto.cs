namespace ArtInk.Infraestructure.Models;

public partial class Impuesto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Porcentaje { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}