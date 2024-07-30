namespace ArtInk.Site.ViewModels.Common;

public class ReservaHorario
{
    private string? hora;
    public string Hora 
    {
        get => hora == null ? Horario.ToString("HH:mm") : hora;
        set => hora = value;
    }

    public TimeOnly Horario { get; set; }
}