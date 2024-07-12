using System.Net;

namespace ArtInk.Site.Models;

public class ArtInkApiClientException : ApplicationException
{
    public LogLevel LogLevel { get; set; } = LogLevel.Information;

    public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.Conflict;

    public ArtInkApiClientException(string message) : base(message) { }
}