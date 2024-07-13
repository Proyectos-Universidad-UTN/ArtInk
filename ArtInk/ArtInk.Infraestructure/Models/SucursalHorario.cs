namespace ArtInk.Infraestructure.Models;

public partial class SucursalHorario
{
    public short Id { get; set; }

    public byte IdSucursal { get; set; }

    public short IdHorario { get; set; }

    public virtual Horario IdHorarioNavigation { get; set; } = null!;
    
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    public virtual ICollection<SucursalHorarioBloqueo> SucursalHorarioBloqueos { get; set; } = new List<SucursalHorarioBloqueo>();
}