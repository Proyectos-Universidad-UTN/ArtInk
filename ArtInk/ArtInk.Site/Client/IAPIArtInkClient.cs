﻿using ArtInk.Site.Configuration;

namespace ArtInk.Site.Client;

public interface IApiArtInkClient
{
    public bool Error { set; get; }

    public string MensajeError { set; get; }

    public string BaseUrlAPI { init; get; }

    public string? BearerToken { set; get; }

    Task<T> ConsumirAPIAsync<T>(string tipoLlamado, string url, string mediaType = Constantes.MEDIATYPEJSON,
                                                                    bool incluyeAuthorization = true,
                                                                   Dictionary<string, string> cabecerasAcceso = default!,
                                                                   params object[] valoresConsumo);
}