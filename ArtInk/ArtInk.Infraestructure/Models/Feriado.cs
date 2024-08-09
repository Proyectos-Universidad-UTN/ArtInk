using ArtInk.Infraestructure.Enums;

namespace ArtInk.Infraestructure.Models;

public partial class Feriado: BaseModel
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public Mes Mes { get; set; }

    public byte Dia { get; set; }

    public virtual ICollection<SucursalFeriado> SucursalFeriados { get; set; } = new List<SucursalFeriado>();
}