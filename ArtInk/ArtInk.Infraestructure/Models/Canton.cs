namespace ArtInk.Infraestructure.Models;

public partial class Canton
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public byte IdProvincia { get; set; }

    public virtual ICollection<Distrito> Distritos { get; set; } = new List<Distrito>();

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;
}