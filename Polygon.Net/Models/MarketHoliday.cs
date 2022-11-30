using Newtonsoft.Json;

namespace Polygon.Net
{
    public class MarketHoliday
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("open")]
        public string Open { get; set; }

        [JsonProperty("close")]
        public string Close { get; set; }
    }
}
