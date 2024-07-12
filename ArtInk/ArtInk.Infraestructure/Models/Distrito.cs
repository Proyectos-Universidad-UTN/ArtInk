namespace ArtInk.Infraestructure.Models;

public partial class Distrito
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public byte IdCanton { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Canton IdCantonNavigation { get; set; } = null!;

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}