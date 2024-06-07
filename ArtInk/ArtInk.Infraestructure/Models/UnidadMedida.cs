namespace ArtInk.Infraestructure.Models;

public partial class UnidadMedida
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Simbolo { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
