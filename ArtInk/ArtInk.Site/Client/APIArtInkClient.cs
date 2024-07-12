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
        var artInkAPI = configuration.GetSection("ArtInkAPI") ?? throw new ArgumentNullException("La sección ArtInkAPI no está configurada.");
        BaseUrlAPI = artInkAPI.GetValue<string>("BaseUrl") ?? throw new ArgumentNullException("El valor de BaseUrl no está configurado.");
    }

    public async Task<T> ConsumirAPIAsync<T>(string tipoLlamado, string url, string mediaType = Constantes.MEDIATYPEJSON,
                                                                   Dictionary<string, string> cabecerasAcceso = default!,
                                                                   params object[] valoresConsumo)
    {
        try
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            string contenidoAPI = String.Empty;
            var inputMessage = new HttpRequestMessage();

            Error = false;

            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

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
                        contenidoAPI = valoresConsumo[0].ToString()!;
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
            throw new Exception(excepcion.Message);
        }
    }
}
