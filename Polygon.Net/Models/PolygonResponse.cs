using Newtonsoft.Json;
using System.Collections.Generic;

namespace Polygon.Net
{
    public class PolygonResponse<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("next_url")]
        public string NextUrl { get; set; }

        [JsonProperty("results")]
        public T Results { get; set; }
    }
}
