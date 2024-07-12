namespace ArtInk.Infraestructure.Models;

public partial class Contacto
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int Telefono { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public byte IdProveedor { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModifiacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}