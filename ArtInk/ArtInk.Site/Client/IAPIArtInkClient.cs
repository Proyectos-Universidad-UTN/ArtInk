using ArtInk.Site.Configuration;

namespace ArtInk.Site.Client
{
    public interface IAPIArtInkClient
    {
        Task<T> ConsumirAPIAsync<T>(string tipoLlamado, string url, string mediaType = Constantes.MEDIATYPEJSON,
                                                                       Dictionary<string, string> cabecerasAcceso = default!,
                                                                       params object[] valoresConsumo);

    }
}
