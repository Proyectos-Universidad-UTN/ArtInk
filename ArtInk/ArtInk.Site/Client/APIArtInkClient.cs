using System.Net;
using System.Net.Http.Headers;
using System.Text;
using ArtInk.Site.Configuration;
using ArtInk.Site.Models;
using ArtInk.Utils;

namespace ArtInk.Site.Client;

public class ApiArtInkClient : IApiArtInkClient
{
    public bool Error { set; get; }
    public string MensajeError { set; get; } = null!;

    public string BaseUrlAPI { init; get; } = null!;

    public ApiArtInkClient(IConfiguration configuration)
    {
        var sectionArtInkApi = configuration.GetSection("ArtInkAPI");
        if (sectionArtInkApi == null) throw new ArgumentNullException(nameof(sectionArtInkApi), "La sección ArtInkAPI no está configurada.");
        var artInkAPI = sectionArtInkApi;

        var baseUrl = artInkAPI.GetValue<string>("BaseUrl");
        if (baseUrl == null) throw new ArgumentNullException(nameof(baseUrl), "El valor de BaseUrl no está configurado.");
        BaseUrlAPI = baseUrl;
    }

    public async Task<T> ConsumirAPIAsync<T>(string tipoLlamado, string url, string mediaType = Constantes.MEDIATYPEJSON,
                                                                   Dictionary<string, string> cabecerasAcceso = default!,
                                                                   params object[] valoresConsumo)
    {
        try
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            var inputMessage = new HttpRequestMessage();

            Error = false;

            using (var client = new HttpClient(clientHandler))
            {
                if (cabecerasAcceso != null)
                {
                    foreach (var header in cabecerasAcceso)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                url = string.Format(BaseUrlAPI, url); // concatenar

                switch (tipoLlamado)
                {
                    case "GET":
                        responseMessage = await client.GetAsync(url);
                        break;
                    case "POST":
                    case "PUT":
                        string contenidoAPI = valoresConsumo[0].ToString()!;
                        inputMessage.Content = new StringContent(contenidoAPI, Encoding.UTF8, mediaType);
                        if (tipoLlamado.Equals("POST"))
                        {
                            responseMessage = await client.PostAsync(url, inputMessage.Content);
                        }
                        else
                        {
                            responseMessage = await client.PutAsync(url, inputMessage.Content);
                        }
                        break;
                    case "DELETE":
                        responseMessage = await client.DeleteAsync(url);
                        break;
                }
            }

            var contenido = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode.Equals(HttpStatusCode.OK) || responseMessage.StatusCode.Equals(HttpStatusCode.Created))
            {
                return Serialization.Deserialize<T>(contenido);
            }

            var responseError = Serialization.Deserialize<ErrorDetailsArtInk>(contenido);

            Error = true;
            MensajeError = responseError.Mensaje!;

            return default!;
        }
        catch (Exception excepcion)
        {
            throw new ArtInkApiClientException(excepcion.Message);
        }
    }
}
