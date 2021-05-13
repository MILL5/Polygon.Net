using Newtonsoft.Json;

namespace Polygon.Net
{
    public class PriceBar
    {
        [JsonProperty("v")]
        public long Volume { get; set; }

        [JsonProperty("vw")]
        public double VolumeWeighted { get; set; }

        [JsonProperty("o")]
        public double Open { get; set; }

        [JsonProperty("c")]
        public double Close { get; set; }

        [JsonProperty("h")]
        public double High { get; set; }

        [JsonProperty("l")]
        public double Low { get; set; }

        [JsonProperty("t")]
        public long Time { get; set; }

        [JsonProperty("n")]
        public long NumberOfTransactions { get; set; }
    }
}