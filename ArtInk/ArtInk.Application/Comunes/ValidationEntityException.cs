using System.Net;
using Microsoft.Extensions.Logging;

namespace ArtInk.Application.Comunes;

[Serializable]
public class ValidationEntityException : BaseException
{
    public override LogLevel LogLevel { get; set; }

    public override HttpStatusCode HttpStatusCode { get; set; }

    public ValidationEntityException(string mensaje) : base(mensaje)
    {    
    }
}