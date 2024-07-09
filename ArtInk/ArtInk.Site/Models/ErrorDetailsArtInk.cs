namespace ArtInk.Site.Models;

public class ErrorDetailsArtInk
{
    public string Type { get; set; } = string.Empty;

    public int StatusCode { get; set; }

    public string? Mensaje { get; set; }

    public string? Detalle { get; set; }

    public LogLevel LogLevel { get; set; }
}