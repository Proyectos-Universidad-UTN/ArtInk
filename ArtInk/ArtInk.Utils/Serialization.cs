﻿using Newtonsoft.Json;

namespace ArtInk.Utils;

public static class Serialization
{
    public static string Serialize<T>(T request)
    {
        return JsonConvert.SerializeObject(request)!;
    }
    public static T Deserialize<T>(string response)
    {
        return JsonConvert.DeserializeObject<T>(response)!;
    }
}