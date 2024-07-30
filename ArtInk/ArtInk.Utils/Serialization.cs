using ArtInk.Utils.Converter;
using Newtonsoft.Json;

namespace ArtInk.Utils;

public static class Serialization
{
    public static string Serialize<T>(T request)
    {
        return JsonConvert.SerializeObject(request)!;
    }
    public static T Deserialize<T>(string response)
    {
        var settings = new JsonSerializerSettings();

        settings.Converters.Add(new DateOnlyJsonConverter());
        settings.Converters.Add(new TimeOnlyJsonConverter());

        return JsonConvert.DeserializeObject<T>(response, settings)!;
    }
}