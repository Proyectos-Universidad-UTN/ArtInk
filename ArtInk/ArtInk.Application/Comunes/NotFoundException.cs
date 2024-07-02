using System.Net;
using Microsoft.Extensions.Logging;

namespace ArtInk.Application.Comunes;

[Serializable]
public class NotFoundException: BaseException
{
    public override LogLevel LogLevel { get; set; } = LogLevel.Information;

    public override HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.NotFound;

    public NotFoundException(string mensaje) : base(mensaje)
    {
    }
}
