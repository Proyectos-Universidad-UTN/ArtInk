using ArtInk.Utils;

namespace ArtInk.WebAPI;

public class ErrorDetailsArtInk
{
    public string Type { get; set; } = string.Empty;

    public int StatusCode { get; set; }

    public string? Mensaje { get; set; }

    public string? Detalle { get; set; }

    public LogLevel LogLevel { get; set; }

    public override string ToString() => Serialization.Serialize(this);
}