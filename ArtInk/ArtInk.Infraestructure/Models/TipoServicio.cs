namespace ArtInk.Infraestructure.Models;

public partial class TipoServicio
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public TimeOnly Duracion { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}