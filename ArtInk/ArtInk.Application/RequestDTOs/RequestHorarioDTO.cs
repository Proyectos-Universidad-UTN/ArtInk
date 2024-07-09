namespace ArtInk.Application.RequestDTOs;

public record RequestHorarioDTO
{
    public short Id { get; set; }

    public DateOnly Dia { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }
}