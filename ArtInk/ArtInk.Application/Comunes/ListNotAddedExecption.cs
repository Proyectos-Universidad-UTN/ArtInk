using System.Net;
using Microsoft.Extensions.Logging;

namespace ArtInk.Application.Comunes;

[Serializable]
public class ListNotAddedExecption : BaseException
{
    public override LogLevel LogLevel { get; set; } = LogLevel.Information;

    public override HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.NotFound;

    public ListNotAddedExecption(string mensaje) : base(mensaje)
    {
    }
}