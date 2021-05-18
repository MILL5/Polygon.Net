using System.Collections.Generic;
using Newtonsoft.Json;

namespace Polygon.Net
{
    public class AggregatesBarsResponse
    {
            [JsonProperty("ticker")]
            public string Ticker { get; set; }
    
            [JsonProperty("status")]
            public string Status { get; set; }
    
            [JsonProperty("queryCount")]
            public long QueryCount { get; set; }
    
            [JsonProperty("resultsCount")]
            public long ResultsCount { get; set; }
    
            [JsonProperty("adjusted")]
            public bool Adjusted { get; set; }
    
            [JsonProperty("results")]
            public List<PriceBar> Results { get; set; }
    
            [JsonProperty("request_id")]
            public string RequestId { get; set; }
    }
}