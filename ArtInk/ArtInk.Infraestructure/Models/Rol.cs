namespace ArtInk.Infraestructure.Models;

public partial class Rol: BaseModel
{
    public byte Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}