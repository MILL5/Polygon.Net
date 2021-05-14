using Newtonsoft.Json;

namespace Polygon.Net
{
    public class TickerDetailsInfo : TickerInfo
    {
        [JsonProperty("outstanding_shares")]
        public long? OutstandingShares { get; set; }

        [JsonProperty("market_cap")]
        public long? MarketCap { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("sic_code")]
        public string SicCode { get; set; }

        [JsonProperty("sic_description")]
        public string SicDescription { get; set; }
    }
}