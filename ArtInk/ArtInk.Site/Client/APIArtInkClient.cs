using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ArtInk.Utils;
using Newtonsoft.Json;

namespace ArtInk.Site.Client
{
    public class APIArtInkClient
    {
        public static bool Error { set; get; }
        public static string MensajeError { set; get; } = null!;


        public static async Task<T> ConsumirAPIAsync<T> (string mediaType, string tipoLlamado ,string url,
                                                                       Dictionary<string,string> cabecerasAcceso,
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
                    foreach (var header in cabecerasAcceso)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

                    switch (tipoLlamado)
                    {
                        case "GET":
                            responseMessage = await client.GetAsync(url);
                            break;
                        case "POST":
                        case "PUT":
                            contenidoAPI = valoresConsumo[0].ToString();
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

                if (!responseMessage.StatusCode.Equals(HttpStatusCode.OK))
                {
                    Error = true;
                    MensajeError = "No se ha procesado la solicitud";

                    return default!;
                }

                if (contenido.ToUpper().Contains("ERROR"))
                {
                    Error = true;
                    MensajeError = ObtenerMensajeError(contenido);
                }

                return Serialization.Deserialize<T>(contenido);
            }
            catch (Exception excepcion)
            {
                throw new Exception(excepcion.Message);
            }
        }

        private static string ObtenerMensajeError(string contenido)
        {
            var mensajes = JsonConvert.DeserializeObject<Dictionary<string, string>>(contenido);
            return mensajes["message"];
            
        }

    }
}
