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
        public int ForFactor { get; set; }

        [JsonProperty("paymentDate")]
        public string PaymentDate { get; set; }

        [JsonProperty("ratio")]
        public decimal Ratio { get; set; }

        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("tofactor")]
        public int ToFactor { get; set; }
    }
}