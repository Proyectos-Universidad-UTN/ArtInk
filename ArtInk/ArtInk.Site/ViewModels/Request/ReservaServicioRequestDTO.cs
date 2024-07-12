using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record ReservaServicioRequestDto
{
    public int Id { get; set; }

    [DisplayName("Reserva")]
    public int IdReserva { get; set; }

    [DisplayName("Servicio")]
    public byte IdServicio { get; set; }
}