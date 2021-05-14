using System;
using Newtonsoft.Json;

namespace Polygon.Net
{
    public class TickerDetailsInfoV1
    {
                [JsonProperty("logo")]
        public Uri Logo { get; set; }

        [JsonProperty("listdate")]
        public DateTimeOffset Listdate { get; set; }

        [JsonProperty("cik")]
        public long? Cik { get; set; }

        [JsonProperty("bloomberg")]
        public string Bloomberg { get; set; }

        [JsonProperty("figi")]
        public object Figi { get; set; }

        [JsonProperty("lei")]
        public string Lei { get; set; }

        [JsonProperty("sic")]
        public long? Sic { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("industry")]
        public string Industry { get; set; }

        [JsonProperty("sector")]
        public string Sector { get; set; }

        [JsonProperty("marketcap")]
        public long? Marketcap { get; set; }

        [JsonProperty("employees")]
        public long? Employees { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("ceo")]
        public string Ceo { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("exchangeSymbol")]
        public string ExchangeSymbol { get; set; }

        [JsonProperty("hq_address")]
        public string HqAddress { get; set; }

        [JsonProperty("hq_state")]
        public string HqState { get; set; }

        [JsonProperty("hq_country")]
        public string HqCountry { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("similar")]
        public string[] Similar { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}