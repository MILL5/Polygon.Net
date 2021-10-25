using Newtonsoft.Json;

namespace Polygon.Net
{
    public class StockSplit
    {
        [JsonProperty("declaredDate")]
        public string DeclaredDate { get; set; }

        [JsonProperty("exDate")]
        public string ExDate { get; set; }

        [JsonProperty("forfactor")]
        public string ForFactor { get; set; }

        [JsonProperty("paymentDate")]
        public string PaymentDate { get; set; }

        [JsonProperty("ratio")]
        public string Ratio { get; set; }

        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("tofactor")]
        public string ToFactor { get; set; }
    }
}