using Newtonsoft.Json;

namespace Polygon.Net
{
    public class ExchangeInfo
    {
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("market")]
        public string Market { get; set; }

        [JsonProperty("mic")]
        public string Mic { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tape")]
        public string Tape { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}