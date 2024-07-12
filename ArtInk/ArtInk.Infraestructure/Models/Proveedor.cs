namespace ArtInk.Infraestructure.Models;

public partial class Proveedor
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string CedulaJuridica { get; set; } = null!;

    public string RasonSocial { get; set; } = null!;

    public int Telefono { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public short IdDistrito { get; set; }

    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual Distrito IdDistritoNavigation { get; set; } = null!;
}