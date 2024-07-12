using System.Net;

namespace ArtInk.Site.Models;

public class ApiClientWrongConfigurationException: ApplicationException
{
    public LogLevel LogLevel { get; set; } = LogLevel.Information;

    public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.NotFound;

    public ApiClientWrongConfigurationException(string message) : base(message) { }
}