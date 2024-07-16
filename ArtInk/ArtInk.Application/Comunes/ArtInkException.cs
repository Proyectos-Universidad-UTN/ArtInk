using System.Net;
using System.Runtime.Serialization;
using Microsoft.Extensions.Logging;

namespace ArtInk.Application.Comunes;

[Serializable]
public class ArtInkException: BaseException
{
    public override LogLevel LogLevel { get; set; } = LogLevel.Information;

    public override HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.Conflict;

    public ArtInkException(string mensaje) : base(mensaje)
    {
    }

    protected ArtInkException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}