using System.Collections.Generic;
using Newtonsoft.Json;

namespace Polygon.Net
{
    public class StockFinancialsResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("results")]
        public List<StockFinancialInfo> Results { get; set; }
    }
}