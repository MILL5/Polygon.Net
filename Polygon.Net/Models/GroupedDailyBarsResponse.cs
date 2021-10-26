using Newtonsoft.Json;
using System.Collections.Generic;

namespace Polygon.Net
{
    public class GroupedDailyBarsResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("queryCount")]
        public long QueryCount { get; set; }

        [JsonProperty("resultsCount")]
        public long ResultsCount { get; set; }

        [JsonProperty("adjusted")]
        public bool Adjusted { get; set; }

        [JsonProperty("results")]
        public List<GroupedDailyPriceBar> Results { get; set; }
    }
}