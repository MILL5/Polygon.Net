using Newtonsoft.Json;

namespace Polygon.Net
{
    public class GroupedDailyPriceBar : PriceBar
    {
        [JsonProperty("T")]
        public string ExchangeSymbol { get; set; }
    }
}