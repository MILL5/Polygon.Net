using Newtonsoft.Json;
using System.Collections.Generic;

namespace Polygon.Net
{
    public class ResponseObject<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("results")]
        public T Results { get; set; }
    }
}
