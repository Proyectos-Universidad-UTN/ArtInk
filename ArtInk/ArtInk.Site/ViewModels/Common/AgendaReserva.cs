using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;

namespace ArtInk.Site.ViewModels.Common;

public class AgendaReserva
{
    public ReservaRequestDto Reserva { get; set; } = null!;

    public IEnumerable<ReservaResponseDto> Reservas { get; set; } = new List<ReservaResponseDto>();

    public string JsonReservas
    {
        get => Serialization.Serialize(Reservas);
    }
}