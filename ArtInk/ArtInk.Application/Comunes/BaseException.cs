using System.Net;
using System.Runtime.Serialization;
using Microsoft.Extensions.Logging;

namespace ArtInk.Application.Comunes;

public abstract class BaseException : ApplicationException
{
    public abstract LogLevel LogLevel { get; set; }

    public abstract HttpStatusCode HttpStatusCode { get; set; }

    protected BaseException(string mensaje) : base(mensaje)
    {   
    }
}