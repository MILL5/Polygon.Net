using Newtonsoft.Json;

namespace Polygon.Net
{
    public class StockDividend
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("exDate")]
        public string ExDate { get; set; }

        [JsonProperty("paymentDate")]
        public string PaymentDate { get; set; }

        [JsonProperty("recordDate")]
        public string RecordDate { get; set; }

        [JsonProperty("ticker")]
        public string Ticker { get; set; }
    }
}