using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record ReservaServicioResponseDto
{
    public int Id { get; set; }

    [DisplayName("Reserva")]
    public int IdReserva { get; set; }

    [DisplayName("Servicio")]
    public byte IdServicio { get; set; }

    public virtual ReservaResponseDto Reserva { get; set; } = null!;

    public virtual ServicioResponseDto Servicio { get; set; } = null!;
}