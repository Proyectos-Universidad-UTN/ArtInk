using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtInk.Infraestructure.Models;

public partial class ReservaPregunta: BaseModel
{
    public int Id { get; set; }

    public int IdReserva { get; set; }

    public string Pregunta { get; set; } = null!;

    [Column(TypeName = "NVARCHAR")]
    [StringLength(250)]
    public string? Respuesta { get; set; }

    public bool Activo { get; set; }

    public virtual Reserva IdReservaNavigation { get; set; } = null!;
}