using Newtonsoft.Json;
using System.Collections.Generic;

namespace Polygon.Net
{
    public class StockSplitsResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public List<StockSplit> Results { get; set; }
    }
}