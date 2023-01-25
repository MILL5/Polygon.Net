using System;
using Newtonsoft.Json;

namespace Polygon.Net
{
    public class TickerDetailsInfo : TickerInfo
    {
        [JsonProperty("ticker_root")]
        public string TickerRoot { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("homepage_url")]
        public string HomePageUrl { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("share_class_shares_outstanding")]
        public long? ShareClassSharesOutstanding { get; set; }

        [JsonProperty("weighted_shares_outstanding")]
        public long? WeightedSharesOutstanding { get; set; }

        [JsonProperty("market_cap")]
        public long? MarketCap { get; set; }

        [JsonProperty("list_date")]
        public DateTime ListDate { get; set; }

        [JsonProperty("sic_code")]
        public string SicCode { get; set; }

        [JsonProperty("sic_description")]
        public string SicDescription { get; set; }
    }
}
