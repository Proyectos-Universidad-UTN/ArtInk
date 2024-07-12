namespace ArtInk.Infraestructure.Models;

public partial class Provincia
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Canton> Cantons { get; set; } = new List<Canton>();
}