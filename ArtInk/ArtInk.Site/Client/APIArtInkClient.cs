﻿using System.Net;
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

    public string? BearerToken { set; get; }

    private readonly IHttpContextAccessor HttpContextAccessor;

    public ApiArtInkClient(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        HttpContextAccessor = httpContextAccessor;
        var artInkAPI = configuration.GetSection("ArtInkAPI") ?? throw new ApiClientWrongConfigurationException("La sección ArtInkAPI no está configurada.");
        BaseUrlAPI = artInkAPI.GetValue<string>("BaseUrl") ?? throw new ApiClientWrongConfigurationException("El valor de BaseUrl no está configurado.");
    }

    public async Task<T> ConsumirAPIAsync<T>(string tipoLlamado, string url, string mediaType = Constantes.MEDIATYPEJSON,
                                                                   bool incluyeAuthorization = true,
                                                                   Dictionary<string, string> cabecerasAcceso = default!,
                                                                   params object[] valoresConsumo)
    {
        var exceptionGeneral = new ArtInkApiClientException();
        try
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            var inputMessage = new HttpRequestMessage();

            Error = false;

            using (var client = new HttpClient(clientHandler))
            {
                if (incluyeAuthorization)
                {
                    var jwtCookie = HttpContextAccessor.HttpContext!.Request.Cookies["JWT"];
                    if (jwtCookie == null)
                    {
                        exceptionGeneral.HttpStatusCode = HttpStatusCode.Unauthorized;
                        throw exceptionGeneral;
                    }

                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtCookie}");
                }

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

            if (responseMessage.StatusCode.Equals(HttpStatusCode.Forbidden))
            {
                exceptionGeneral.HttpStatusCode = HttpStatusCode.Forbidden;
                HttpContextAccessor.HttpContext!.Session.SetString("MensajeAuth", "No posee acceso a este recurso");
                throw exceptionGeneral;
            }

            if (responseMessage.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                exceptionGeneral.HttpStatusCode = HttpStatusCode.Unauthorized;
                HttpContextAccessor.HttpContext!.Session.SetString("MensajeAuth", "Favor autenticarse en el sistema");
                throw exceptionGeneral;
            }

            var responseError = Serialization.Deserialize<ErrorDetailsArtInk>(contenido);

            Error = true;
            MensajeError = responseError.Mensaje!;

            return default!;
        }
        catch (Exception excepcion)
        {
            var exceptionArtInk = new ArtInkApiClientException(excepcion.Message);
            exceptionArtInk.HttpStatusCode = exceptionGeneral.HttpStatusCode;
            throw exceptionArtInk;
        }
    }
}
