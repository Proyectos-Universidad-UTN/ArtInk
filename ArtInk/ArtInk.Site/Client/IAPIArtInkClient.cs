using ArtInk.Site.Configuration;

namespace ArtInk.Site.Client;

public interface IAPIArtInkClient
{
    public bool Error { set; get; }

    public string MensajeError { set; get; }

    public string BaseUrlAPI { init; get; }

    Task<T> ConsumirAPIAsync<T>(string tipoLlamado, string url, string mediaType = Constantes.MEDIATYPEJSON,
                                                                   Dictionary<string, string> cabecerasAcceso = default!,
                                                                   params object[] valoresConsumo);
}