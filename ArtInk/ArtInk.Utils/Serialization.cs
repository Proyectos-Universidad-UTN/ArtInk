using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ArtInk.Utils
{
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
}
