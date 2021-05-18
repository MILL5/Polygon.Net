using Newtonsoft.Json;
using System.Collections.Generic;

namespace Polygon.Net
{
    public class DailyOpenCloseResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("close")]
        public double Close { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }

        [JsonProperty("afterHours")]
        public double AfterHours { get; set; }

        [JsonProperty("preMarket")]
        public double PreMarket { get; set; }
    }
}