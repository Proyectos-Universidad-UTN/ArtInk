namespace ArtInk.Infraestructure.Models;

public partial class Categoria: BaseModel
{
    public byte Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}