using Newtonsoft.Json;

namespace Polygon.Net
{
    public class TickerDetailsResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public TickerDetailsInfo Results { get; set; }
    }
}