using System.Collections.Generic;
using Newtonsoft.Json;

namespace Polygon.Net
{
    public class StockDividendsResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public List<StockDividend> Results { get; set; }
    }
}