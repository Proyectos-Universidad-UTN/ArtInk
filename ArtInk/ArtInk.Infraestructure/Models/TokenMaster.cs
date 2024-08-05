using System.ComponentModel.DataAnnotations;

namespace ArtInk.Infraestructure.Models;

public class TokenMaster
{
    public long Id { get; set; }

    [StringLength(250)]
    public string Token { get; set; } = null!;

    [StringLength(250)]
    public string JwtId { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public bool Utilizado { get; set; }

    public short IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}